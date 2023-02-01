using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_tautulli_info-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_tautulli_info" />
    [Measurement("tautulli_info")]
    public class TautulliInfo
    {
        [JsonProperty("tautulli_version")]
        [Column("tautulli_version", IsTag = true)]
        public string Version { get; set; } = default!;

        [JsonProperty("tautulli_branch")]
        [Column("tautulli_branch", IsTag = true)]
        public string Branch { get; set; } = default!;

        [JsonProperty("tautulli_commit")]
        [Column("tautulli_commit", IsTag = true)]
        public string Commit { get; set; } = default!;

        [Column("value")]
        public string Value => Commit;
    };
}