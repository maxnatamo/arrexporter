using Flurl;
using Flurl.Http;
using Serilog;
using Newtonsoft.Json;

using ArrExporter.Models;

namespace ArrExporter.Tautulli
{
    /// <summary>
    /// Wrapper around the Tautulli API queries.
    /// </summary>
    public class TautulliClient
    {
        /// <summary>
        /// The connection string to use for Tautulli.
        /// </summary>
        private readonly TautulliConnectionString connectionString;

        /// <summary>
        /// The underlying Flurl.Url to use as a base for all queries.
        /// </summary>
        private readonly Url apiEndpoint;

        /// <summary>
        /// Create a new TautulliClient-wrapper.
        /// </summary>
        /// <param name="connectionString">The connection string to connect with.</param>
        public TautulliClient(TautulliConnectionString connectionString)
        {
            this.connectionString = connectionString;

            this.apiEndpoint = Url.Combine(connectionString.Url, "/api/v2");
        }

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
        /// Query the Tautulli API with the specified command and optional arguments.
        /// </summary>
        /// <param name="cmd">The Tautulli API command to query. </param>
        /// <param name="args">Optional arguments to the API query.</param>
        /// <param name="selector">An optional selector for nested JSON objects.</param>
        /// <typeparam name="T">The model to use for model binding.</typeparam>
        /// <returns>The resulting model from the API</returns>
        /// <exception cref="InvalidDataException">Thrown if the returned model is invalid.</exception>
        /// <seealso cref="Broker.Render">Example of using Query</seealso>
        /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference">Tautulli API reference</seealso>
        public async Task<T> Query<T>(string cmd, object? args = null, Func<dynamic, dynamic>? selector = null)
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