using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_pms_update-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_pms_update" />
    [Measurement("pms_update")]
    public class PlexUpdate
    {
        [JsonProperty("update_available")]
        [Column("update_available", IsTag = true)]
        public bool UpdateAvailable { get; set; }

        [JsonProperty("release_date")]
        [Column("release_date", IsTag = true)]
        public string ReleaseDate { get; set; } = default!;

        [JsonProperty("version")]
        [Column("version", IsTag = true)]
        public string Version { get; set; } = default!;

        [JsonProperty("label")]
        [Column("label", IsTag = true)]
        public string Label { get; set; } = default!;

        [JsonProperty("distro")]
        [Column("distro", IsTag = true)]
        public string Distro { get; set; } = default!;

        [JsonProperty("distro_build")]
        [Column("distro_build", IsTag = true)]
        public string DistroBuild { get; set; } = default!;

        [Column("value")]
        public string Value => Version;
    };
}