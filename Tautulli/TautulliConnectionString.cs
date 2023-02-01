namespace ArrExporter.Tautulli
{
    /// <summary>
    /// Structure for defining connection strings to a Tautulli API endpoint.
    /// </summary>
    public class TautulliConnectionString
    {
        /// <summary>
        /// The Url, hostname or address of the Tautulli server. No subpaths should be included.
        /// </summary>
        /// <example>
        /// http://10.0.0.10:8181
        /// </example>
        public string Url { get; set; } = default!;

        /// <summary>
        /// The API key to use for authentication. This can be retrieved from Tautulli's settings.
        /// </summary>
        public string ApiKey { get; set; } = default!;
    }
}