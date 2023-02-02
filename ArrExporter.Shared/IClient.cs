namespace ArrExporter.Shared
{
    /// <summary>
    /// Interface for all module clients.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Returns the name of the client.
        /// </summary>
        public string Name();

        /// <summary>
        /// Pings the client to check connection and authentication.
        /// </summary>
        /// <returns>True, if the connection is valid and authenticated. Otherwise, false.</returns>
        public Task<bool> PingAsync();

        /// <summary>
        /// Query the respective API and ingest them into Influx.
        /// </summary>
        public Task Render();
    }
}