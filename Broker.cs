using ArrExporter.Influx;
using ArrExporter.Tautulli;
using ArrExporter.Models;

namespace ArrExporter
{
    /// <summary>
    /// Internal data broker between Tautulli and the Influx database.
    /// </summary>
    public class Broker
    {
        /// <summary>
        /// The InfluxClient to use for ingesting.
        /// </summary>
        private readonly InfluxClient influxClient;

        /// <summary>
        /// The TautulliClient to use for querying.
        /// </summary>
        private readonly TautulliClient tautulliClient;

        /// <summary>
        /// Create a new Broker-instance.
        /// </summary>
        /// <param name="influxClient">The InfluxClient to use for ingesting.</param>
        /// <param name="tautulliClient">The TautulliClient to use for querying.</param>
        public Broker(InfluxClient influxClient, TautulliClient tautulliClient)
        {
            this.influxClient = influxClient;
            this.tautulliClient = tautulliClient;
        }

        /// <summary>
        /// Query metrics from Tautulli and ingest them into InfluxDB.
        /// </summary>
        public async Task Render()
        {
            await this.RenderDataPoint<PlexServerInfo>("get_server_info");
            await this.RenderDataPoint<TautulliInfo>("get_tautulli_info");
            await this.RenderDataPoint<StreamStatistics>("get_activity");
            await this.RenderDataPointList<Session>("get_activity", null, res => res.sessions);
            await this.RenderDataPointList<Libraries>("get_libraries");
            await this.RenderDataPointList<LibraryNames>("get_library_names");
            await this.RenderDataPointList<Usernames>("get_user_names");
        }

        /// <summary>
        /// Query and ingest a single model from the Tautulli API.
        /// </summary>
        /// <param name="cmd">The Tautulli API command to execute.</param>
        /// <param name="args">Optional arguments to the command.</param>
        /// <param name="selector">Optional selector to use for nested JSON-objects.</param>
        /// <typeparam name="T">The model to use for data-binding.</typeparam>
        protected async Task RenderDataPoint<T>(string cmd, object? args = null, Func<dynamic, dynamic>? selector = null)
        {
            var data = await this.tautulliClient.Query<T>(cmd, args, selector);

            this.influxClient.Write(api => api.WriteMeasurement(data));
        }

        /// <summary>
        /// Query and ingest a list of models from the Tautulli API.
        /// </summary>
        /// <param name="cmd">The Tautulli API command to execute.</param>
        /// <param name="args">Optional arguments to the command.</param>
        /// <param name="selector">Optional selector to use for nested JSON-objects.</param>
        /// <typeparam name="T">The model to use for data-binding. The model should NOT use List or Enumerable.</typeparam>
        protected async Task RenderDataPointList<T>(string cmd, object? args = null, Func<dynamic, dynamic>? selector = null)
        {
            var data = await this.tautulliClient.Query<List<T>>(cmd, args, selector);

            this.influxClient.Write(api => api.WriteMeasurements(data));
        }
    }
}