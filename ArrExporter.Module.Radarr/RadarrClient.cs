using Flurl;
using Flurl.Http;
using Serilog;
using Newtonsoft.Json;

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
        /// The underlying Flurl.Url to use as a base for all queries.
        /// </summary>
        private readonly Url apiEndpoint;

        /// <summary>
        /// Create a new RadarrClient-wrapper.
        /// </summary>
        /// <param name="connectionString">The connection string to connect with.</param>
        public RadarrClient(RadarrConnectionString connectionString)
        {
            this.connectionString = connectionString;
            this.apiEndpoint = Url.Combine(connectionString.Url, "/api/v3");
        }

        /// <summary>
        /// Ping the server to determine if the client is authenticated.
        /// </summary>
        /// <returns>True, if the client is connected and authenticated. Otherwise, false.</returns>
        public async Task<bool> PingAsync()
        {
            var url = this.apiEndpoint.WithHeader("X-Api-Key", this.connectionString.ApiKey);

            url = url.AppendPathSegment("/not_a_real_path");

            try
            {
                await url.GetAsync();
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

                throw e;
            }
            
            return true;
        }

        /// <summary>
        /// Query metrics from Radarr and ingest them into InfluxDB.
        /// </summary>
        public async Task Render()
        {

        }
    }
}