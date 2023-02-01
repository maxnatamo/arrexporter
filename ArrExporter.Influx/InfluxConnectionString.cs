namespace ArrExporter.Influx
{
    /// <summary>
    /// Structure for defining connection strings to an InfluxDB server.
    /// </summary>
    public class InfluxConnectionString
    {
        /// <summary>
        /// The Url, hostname or address of the server.
        /// </summary>
        public string Url { get; set; } = default!;

        /// <summary>
        /// The user token to authenticate with.
        /// </summary>
        public string Token { get; set; } = default!;

        /// <summary>
        /// Which organization the data should be grouped in.
        /// </summary>
        public string Organization { get; set; } = default!;

        /// <summary>
        /// The bucket to write data into.
        /// </summary>
        public string Bucket { get; set; } = default!;
    }
}