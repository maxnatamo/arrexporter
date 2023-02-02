using Flurl;
using Flurl.Http;
using Serilog;
using Newtonsoft.Json;

using ArrExporter.Shared;
using ArrExporter.Influx;
using ArrExporter.Module.Tautulli.Models;

namespace ArrExporter.Module.Tautulli
{
    /// <summary>
    /// Wrapper around the Tautulli API queries.
    /// </summary>
    public class TautulliClient : IClient
    {
        /// <summary>
        /// The connection string to use for Tautulli.
        /// </summary>
        private readonly TautulliConnectionString connectionString;

        /// <summary>
        /// The InfluxClient to use for ingesting.
        /// </summary>
        private readonly InfluxClient influxClient;

        /// <summary>
        /// The underlying Flurl.Url to use as a base for all queries.
        /// </summary>
        private readonly Url apiEndpoint;

        /// <summary>
        /// Create a new TautulliClient-wrapper.
        /// </summary>
        /// <param name="connectionString">The connection string to connect with.</param>
        public TautulliClient(TautulliConnectionString connectionString, InfluxClient influxClient)
        {
            this.connectionString = connectionString;
            this.influxClient = influxClient;

            this.apiEndpoint = Url.Combine(connectionString.Url, "/api/v2");
        }

        /// <summary>
        /// Returns the name of the client.
        /// </summary>
        /// <returns>"Tautulli" as string.</returns>
        public string Name() => "Tautulli";

        /// <summary>
        /// Ping the server to determine if the client is authenticated.
        /// </summary>
        /// <returns>True, if the client is connected and authenticated. Otherwise, false.</returns>
        public async Task<bool> PingAsync()
        {
            var url = this.apiEndpoint.SetQueryParams(new
            {
                apikey = this.connectionString.ApiKey,
                cmd = "arnold"
            });

            try
            {
                await url.GetAsync();
            }
            catch(FlurlHttpException e)
            {
                // If not a BadReqest error, something else might've happened.
                if(e.StatusCode != 400)
                {
                    throw e;
                }

                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Query metrics from Tautulli and ingest them into InfluxDB.
        /// </summary>
        public async Task Render()
        {
            /* Save reponses that might be used for other requests. */
            List<Libraries> libraries = await this.RenderDataPointList<Libraries>("get_libraries");
            List<Usernames> usernames = await this.RenderDataPointList<Usernames>("get_user_names");

            await this.RenderDataPoint<PlexServerInfo>("get_server_info");
            await this.RenderDataPoint<TautulliInfo>("get_tautulli_info");
            await this.RenderDataPoint<PlexStatus>("server_status");
            await this.RenderDataPoint<PlexUpdate>("get_pms_update");

            await this.RenderDataPoint<StreamStatistics>("get_activity");
            await this.RenderDataPointList<Session>("get_activity", null, res => res.sessions);
            await this.RenderDataPointList<LibraryNames>("get_library_names");

            foreach(var library in libraries)
            {
                await this.RenderDataPointList<LibraryUserStats>(
                    "get_library_user_stats", new
                    {
                        section_id = library.SectionId
                    });
            }

            foreach(var user in usernames)
            {
                if(user.UserId == 0)
                {
                    continue;
                }

                await this.RenderDataPoint<Users>(
                    "get_user", new
                    {
                        user_id = user.UserId,
                        include_last_seen = true
                    });
            }
        }

        /// <summary>
        /// Query and ingest a single model from the Tautulli API.
        /// </summary>
        /// <param name="cmd">The Tautulli API command to execute.</param>
        /// <param name="args">Optional arguments to the command.</param>
        /// <param name="selector">Optional selector to use for nested JSON-objects.</param>
        /// <typeparam name="T">The model to use for data-binding.</typeparam>
        /// <returns>The data fetched from the API.</returns>
        protected async Task<T> RenderDataPoint<T>(string cmd, object? args = null, Func<dynamic, dynamic>? selector = null)
        {
            var data = await this.Query<T>(cmd, args, selector);

            this.influxClient.Write(api => api.WriteMeasurement(data));

            return data;
        }

        /// <summary>
        /// Query and ingest a list of models from the Tautulli API.
        /// </summary>
        /// <param name="cmd">The Tautulli API command to execute.</param>
        /// <param name="args">Optional arguments to the command.</param>
        /// <param name="selector">Optional selector to use for nested JSON-objects.</param>
        /// <typeparam name="T">The model to use for data-binding. The model should NOT use List or Enumerable.</typeparam>
        /// <returns>The data fetched from the API.</returns>
        protected async Task<List<T>> RenderDataPointList<T>(string cmd, object? args = null, Func<dynamic, dynamic>? selector = null)
        {
            var data = await this.Query<List<T>>(cmd, args, selector);

            this.influxClient.Write(api => api.WriteMeasurements(data));

            return data;
        }

        /// <summary>
        /// Query the Tautulli API with the specified command and optional arguments.
        /// </summary>
        /// <param name="cmd">The Tautulli API command to query. </param>
        /// <param name="args">Optional arguments to the API query.</param>
        /// <param name="selector">An optional selector for nested JSON objects.</param>
        /// <typeparam name="T">The model to use for model binding.</typeparam>
        /// <returns>The resulting model from the API</returns>
        /// <exception cref="InvalidDataException">Thrown if the returned model is invalid.</exception>
        /// <seealso cref="Render">Example of using Query</seealso>
        /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference">Tautulli API reference</seealso>
        private async Task<T> Query<T>(string cmd, object? args = null, Func<dynamic, dynamic>? selector = null)
        {
            var url = this.apiEndpoint.SetQueryParams(new
            {
                apikey = this.connectionString.ApiKey,
                cmd = cmd
            });

            if(args != null)
            {
                url.SetQueryParams(args);
            }

            string result = await (await url.GetAsync()).GetStringAsync();

            TautulliResponse? response = JsonConvert.DeserializeObject<TautulliResponse>(result);
            if(response == null || response.Response == null || response.Response.Data == null)
            {
                Log.Fatal("Failed to query Tautulli API: cmd={0}", cmd);
                throw new InvalidDataException();
            }

            dynamic? data = response?.Response?.Data;
            if(data == null)
            {
                Log.Fatal("Failed to deserialize Tautulli response: cmd={0}", cmd);
                throw new InvalidDataException();
            }

            if(selector != null)
            {
                data = selector(data);
            }

            string json = JsonConvert.SerializeObject(data);
            T? obj = JsonConvert.DeserializeObject<T>(json);

            if(obj == null)
            {
                Log.Fatal("Failed to deserialize Tautulli response: cmd={0}", cmd);
                throw new InvalidDataException();
            }

            return obj;
        }
    }
}