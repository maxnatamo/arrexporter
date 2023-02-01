using Serilog;

using InfluxDB.Client;
using InfluxDB.Client.Core.Exceptions;
using InfluxDB.Client.Writes;

namespace ArrExporter.Influx
{
    /// <summary>
    /// Wrapper around the InfluxDB.Client package.
    /// </summary>
    public class InfluxClient
    {
        /// <summary>
        /// The underlying InfluxDB.Client.Client-instance.
        /// </summary>
        private readonly InfluxDBClient client;

        /// <summary>
        /// Create a new InfluxClient-wrapper.
        /// </summary>
        /// <param name="connectionString">The connection string to connect with.</param>
        public InfluxClient(InfluxConnectionString connectionString)
        {
            var options = new InfluxDBClientOptions(connectionString.Url);
            options.Bucket = connectionString.Bucket;
            options.Token = connectionString.Token;
            options.Org = connectionString.Organization;

            this.client = new InfluxDBClient(options);
            this.client.SetLogLevel(InfluxDB.Client.Core.LogLevel.Body);
        }

        /// <summary>
        /// Ping the server to determine if the client is authenticated.
        /// </summary>
        /// <returns>True, if the client is connected and authenticated. Otherwise, false.</returns>
        public async Task<bool> PingAsync()
        {
            // There might be a better way of doing this,
            // but the Healthcheck-method is obselete and doesn't require auth.

            var queryApi = this.client.GetBucketsApi();

            try
            {
                await queryApi.FindBucketsAsync(0, 1);
            }
            catch(UnauthorizedException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Perform a query-action with the client, using the specified action.
        /// </summary>
        /// <param name="action">Action with the current QueryApi-instance.</param>
        public void Query(Action<QueryApi> action)
        {
            var query = client.GetQueryApi();

            action(query);
        }

        /// <summary>
        /// Perform a write-action with the client, using the specified action.
        /// </summary>
        /// <remarks>This method also attaches an event handler, to listen for logging.</remarks>
        /// <param name="action">Action with the current WriteApi-instance.</param>
        public void Write(Action<WriteApi> action)
        {
            using var write = client.GetWriteApi();

            write.EventHandler += DefaultEventHandler;

            action(write);
        }

        /// <summary>
        /// <para>
        /// The default event handler for logging.
        /// </para>
        /// <para>
        /// This is automatically attached to WriteApi-instances when using Write.
        /// </para>
        /// </summary>
        private void DefaultEventHandler(object? sender, EventArgs eventArgs)
        {
            switch (eventArgs)
            {
                case WriteSuccessEvent e:
                    Log.Debug("Point(s) was successfully written to InfluxDB");
                    Log.Debug("  - {0}", e.LineProtocol);
                    Log.Debug("-----------------------------------------------------------------------");
                    break;

                case WriteErrorEvent e:
                    Log.Error("Point(s) failed to be written to InfluxDB");
                    Log.Error("  -> {0}", e.Exception.Message);
                    Log.Error("  -> {0}", e.LineProtocol);
                    Log.Error("-----------------------------------------------------------------------");
                    break;

                case WriteRetriableErrorEvent e:
                    Log.Error("Point(s) failed to be written to InfluxDB");
                    Log.Error("  -> {0}", e.Exception.Message);
                    Log.Error("  -> {0}", e.LineProtocol);
                    Log.Error("-----------------------------------------------------------------------");
                    break;

                case WriteRuntimeExceptionEvent e:
                    Log.Fatal("Point(s) failed to be written to InfluxDB:");
                    Log.Fatal("  -> {0}", e.Exception.Message);
                    Log.Fatal("-----------------------------------------------------------------------");
                    break;
            }
        }
    }
}