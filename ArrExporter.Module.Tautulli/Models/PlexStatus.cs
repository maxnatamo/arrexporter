using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Module.Tautulli.Models
{
    /// <summary>
    /// Model for the server_status-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#server_status" />
    [Measurement("plex_status")]
    public class PlexStatus
    {
        [JsonProperty("connected")]
        [Column("connected", IsTag = true)]
        public bool Connected { get; set; } = default!;

        [Column("value")]
        public bool Value => Connected;
    };
}