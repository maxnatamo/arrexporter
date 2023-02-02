using Flurl;
using Flurl.Http;
using Serilog;
using Newtonsoft.Json;

using ArrExporter.Influx;
using ArrExporter.Module.Radarr.Models;
using ArrExporter.Shared;

namespace ArrExporter.Module.Radarr
{
    /// <summary>
    /// Wrapper around the Radarr API queries.
    /// </summary>
    public class RadarrClient : IClient
    {
        /// <summary>
        /// The connection string to use for Radarr.
        /// </summary>
        private readonly RadarrConnectionString connectionString;

        /// <summary>
        /// The InfluxClient to use for ingesting.
        /// </summary>
        private readonly InfluxClient influxClient;

        /// <summary>
        /// The underlying Flurl.Url to use as a base for all queries.
        /// </summary>
        private readonly Url apiEndpoint;

        /// <summary>
        /// Create a new RadarrClient-wrapper.
        /// </summary>
        /// <param name="connectionString">The connection string to connect with.</param>
        public RadarrClient(RadarrConnectionString connectionString, InfluxClient influxClient)
        {
            this.connectionString = connectionString;
            this.influxClient = influxClient;

            this.apiEndpoint = Url.Combine(connectionString.Url, "/api/v3");
        }

        /// <summary>
        /// Returns the name of the client.
        /// </summary>
        /// <returns>"Radarr" as string.</returns>
        public string Name() => "Radarr";

        /// <summary>
        /// Ping the server to determine if the client is authenticated.
        /// </summary>
        /// <returns>True, if the client is connected and authenticated. Otherwise, false.</returns>
        public async Task<bool> PingAsync()
        {
            var request = this.apiEndpoint.Clone()
                .WithHeader("X-Api-Key", this.connectionString.ApiKey)
                .AppendPathSegment("/not_a_real_path");

            try
            {
                await request.GetAsync();
            }
            catch(FlurlHttpException e)
            {
                if(e.StatusCode == 404)
                {
                    return true;
                }

                if(e.StatusCode == 401)
                {
                    return false;
                }

                Log.Fatal("Unhandled exception when pinging Radarr: {Message}", e.Message);
                throw e;
            }
            
            return true;
        }

        /// <summary>
        /// Query metrics from Radarr and ingest them into InfluxDB.
        /// </summary>
        public async Task Render()
        {
            await RenderDataPointList<Movies>("movie");
        }

        /// <summary>
        /// Query and ingest a single model from the Radarr API.
        /// </summary>
        /// <param name="endpoint">Endpoint to query.</param>
        /// <typeparam name="T">The model to use for data-binding.</typeparam>
        /// <returns>The data fetched from the API.</returns>
        protected async Task<T> RenderDataPoint<T>(params object[] endpoint)
        {
            var data = await this.Query<T>(endpoint);

            this.influxClient.Write(api => api.WriteMeasurement(data));

            return data;
        }

        /// <summary>
        /// Query and ingest a list of models from the Radarr API.
        /// </summary>
        /// <param name="endpoint">Endpoint to query.</param>
        /// <typeparam name="T">The model to use for data-binding. The model should NOT use List or Enumerable.</typeparam>
        /// <returns>The data fetched from the API.</returns>
        protected async Task<List<T>> RenderDataPointList<T>(params object[] endpoint)
        {
            var data = await this.Query<List<T>>(endpoint);

            this.influxClient.Write(api => api.WriteMeasurements(data));

            return data;
        }

        /// <summary>
        /// Query the Radarr API at the specified endpoint and optional path segments.
        /// </summary>
        /// <param name="endpoint">Endpoint to query.</param>
        /// <typeparam name="T">The model to use for model binding.</typeparam>
        /// <returns>The resulting model from the API</returns>
        /// <exception cref="InvalidDataException">Thrown if the returned model is invalid.</exception>
        /// <seealso cref="Render">Example of using Query</seealso>
        private async Task<T> Query<T>(params object[] endpoint)
        {
            var request = this.apiEndpoint.Clone()
                .WithHeader("X-Api-Key", this.connectionString.ApiKey)
                .AppendPathSegments(endpoint);

            string reponse = await (await request.GetAsync()).GetStringAsync();

            T? model = JsonConvert.DeserializeObject<T>(reponse);
            if(model == null)
            {
                Log.Fatal("Failed to deserialize Radarr response: endpoint={0}", endpoint.Select(e => e.ToString()));
                throw new InvalidDataException();
            }

            return model;
        }
    }
}