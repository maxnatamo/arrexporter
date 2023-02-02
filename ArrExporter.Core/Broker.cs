using Serilog;

using ArrExporter.Influx;
using ArrExporter.Module.Tautulli;
using ArrExporter.Module.Radarr;
using ArrExporter.Shared;
using ArrExporter.Shared.Exceptions;

namespace ArrExporter.Core
{
    /// <summary>
    /// Wrapper class around all enabled modules and the Influx client.
    /// </summary>
    public static class Broker
    {
        /// <summary>
        /// List of currently enabled clients.
        /// </summary>
        private static List<IClient> clients = new List<IClient>();

        /// <summary>
        /// Initialize the broker and all underlying modules.
        /// </summary>
        public static async Task Initialize()
        {
            InfluxClient influxClient = Broker.InitializeInfluxClient();

            /**
             * Tautulli
             */

            if((Environment.GetEnvironmentVariable("TAUTULLI_ENABLED") ?? "false") == "true")
            {
                TautulliConnectionString tautulliConnectionString = new TautulliConnectionString
                {
                    Url = Environment.GetEnvironmentVariable("TAUTULLI_URL")
                        ?? throw new InvalidConfigurationException("TAUTULLI_URL"),

                    ApiKey = Environment.GetEnvironmentVariable("TAUTULLI_API_KEY")
                        ?? throw new InvalidConfigurationException("TAUTULLI_API_KEY"),
                };

                clients.Add(new TautulliClient(tautulliConnectionString, influxClient));
            }

            /**
             * Radarr
             */

            if((Environment.GetEnvironmentVariable("RADARR_ENABLED") ?? "false") == "true")
            {
                RadarrConnectionString radarrConnectionString = new RadarrConnectionString
                {
                    Url = Environment.GetEnvironmentVariable("RADARR_URL")
                        ?? throw new InvalidConfigurationException("RADARR_URL"),

                    ApiKey = Environment.GetEnvironmentVariable("RADARR_API_KEY")
                        ?? throw new InvalidConfigurationException("RADARR_API_KEY"),
                };

                clients.Add(new RadarrClient(radarrConnectionString, influxClient));
            }

            if(clients.Count == 0)
            {
                Log.Fatal("No clients configured. Exiting...");
                Environment.Exit(1);
            }

            /**
             * Ping all clients to ensure connection.
             */

            foreach(var client in clients)
            {
                bool pong = await client.PingAsync();

                if(!pong)
                {
                    Log.Fatal("{Name} client failed to connect.", client.Name());
                    Environment.Exit(1);
                }
                else
                {
                    Log.Information("{Name} client connected.", client.Name());
                }
            }
        }

        /// <summary>
        /// Query metrics from all clients and ingest them into InfluxDB.
        /// </summary>
        public static async Task Render()
        {
            // TODO: Do in parallel
            foreach(var client in clients)
            {
                await client.Render();
            }
        }

        /// <summary>
        /// Create a new InfluxClient and read configuration from environment variables.
        /// </summary>
        /// <returns>A Task whose result is the resulting InfluxClient.</returns>
        private static InfluxClient InitializeInfluxClient()
        {
            InfluxConnectionString influxConnectionString = new InfluxConnectionString
            {
                Url = Environment.GetEnvironmentVariable("INFLUX_URL")
                    ?? throw new ArgumentNullException("INFLUX_URL"),

                Token = Environment.GetEnvironmentVariable("INFLUX_TOKEN")
                    ?? throw new ArgumentNullException("INFLUX_TOKEN"),

                Organization = Environment.GetEnvironmentVariable("INFLUX_ORG")
                    ?? throw new ArgumentNullException("INFLUX_ORG"),

                Bucket = Environment.GetEnvironmentVariable("INFLUX_BUCKET")
                    ?? throw new ArgumentNullException("INFLUX_BUCKET"),
            };

            return new InfluxClient(influxConnectionString);
        }
    }
}