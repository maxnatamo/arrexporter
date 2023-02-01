namespace ArrExporter.Module.Radarr
{
    /// <summary>
    /// Structure for defining connection strings to a Tautulli API endpoint.
    /// </summary>
    public class RadarrConnectionString
    {
        /// <summary>
        /// The Url, hostname or address of the Radarr server.
        /// No subpaths should be included, the the scheme should.
        /// </summary>
        /// <example>
        /// http://10.0.0.10:7878
        /// </example>
        public string Url { get; set; } = default!;

        /// <summary>
        /// The API key to use for authentication. This can be retrieved from Radarr's settings.
        /// </summary>
        public string ApiKey { get; set; } = default!;
    }
}