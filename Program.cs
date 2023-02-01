using Serilog;

using ArrExporter.Influx;
using ArrExporter.Tautulli;

namespace ArrExporter
{
    public static class Program
    {
        /// <summary>
        /// Create a new InfluxClient and read configuration from environment variables.
        /// </summary>
        /// <returns>A Task whose result is the resulting InfluxClient.</returns>
        private static async Task<InfluxClient> CreateInfluxClient()
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

            InfluxClient client = new InfluxClient(influxConnectionString);

            if(!await client.PingAsync())
            {
                Log.Fatal("Failed to connect to InfluxDB");
                Environment.Exit(1);
            }

            Log.Information("InfluxDB client has been connected.");

            return client;
        }

        /// <summary>
        /// Create a new TautulliClient and read configuration from environment variables.
        /// </summary>
        /// <returns>A Task whose result is the resulting TautulliClient.</returns>
        private static async Task<TautulliClient> CreateTautulliClient()
        {
            TautulliConnectionString tautulliConnectionString = new TautulliConnectionString
            {
                Url = Environment.GetEnvironmentVariable("TAUTULLI_URL")
                    ?? throw new ArgumentNullException("TAUTULLI_URL"),

                ApiKey = Environment.GetEnvironmentVariable("TAUTULLI_API_KEY")
                    ?? throw new ArgumentNullException("TAUTULLI_API_KEY")
            };

            var client = new TautulliClient(tautulliConnectionString);

            if(!await client.PingAsync())
            {
                Log.Fatal("Failed to connect to Tatulli API");
                Environment.Exit(1);
            }

            Log.Information("Tautulli client has been connected.");

            return client;
        }

        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            InfluxClient influxClient = await CreateInfluxClient();
            TautulliClient tautulliClient = await CreateTautulliClient();

            Broker broker = new Broker(influxClient, tautulliClient);

            while(true)
            {
                Log.Information("Updating data...");

                await broker.Render();

                Log.Information("Update complete.");

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}