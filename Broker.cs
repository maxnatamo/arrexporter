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
                await this.RenderDataPointList<Users>(
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
            var data = await this.tautulliClient.Query<T>(cmd, args, selector);

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
            var data = await this.tautulliClient.Query<List<T>>(cmd, args, selector);

            this.influxClient.Write(api => api.WriteMeasurements(data));

            return data;
        }
    }
}