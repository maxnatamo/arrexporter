using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_server_info-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_server_info" />
    [Measurement("pms_info")]
    public class PlexServerInfo
    {
        [JsonProperty("pms_identifier")]
        [Column("pms_identifier", IsTag = true)]
        public string Identifier { get; set; } = default!;

        [JsonProperty("pms_url")]
        [Column("pms_url", IsTag = true)]
        public string Url { get; set; } = default!;

        [JsonProperty("pms_ip")]
        [Column("pms_ip", IsTag = true)]
        public string Ip { get; set; } = default!;

        [JsonProperty("pms_port")]
        [Column("pms_port", IsTag = true)]
        public int Port { get; set; }

        [JsonProperty("pms_ssl")]
        [Column("pms_ssl", IsTag = true)]
        public int IsSsl { get; set; }

        [JsonProperty("pms_is_remote")]
        [Column("pms_is_remote", IsTag = true)]
        public int IsRemote { get; set; }

        [JsonProperty("pms_name")]
        [Column("pms_name", IsTag = true)]
        public string Name { get; set; } = default!;

        [JsonProperty("pms_platform")]
        [Column("pms_platform", IsTag = true)]
        public string Platform { get; set; } = default!;

        [JsonProperty("pms_version")]
        [Column("pms_version", IsTag = true)]
        public string Version { get; set; } = default!;

        [JsonProperty("pms_plexpass")]
        [Column("pms_plexpass", IsTag = true)]
        public int PlexPass { get; set; }

        [Column("value")]
        public string Value => Identifier;
    };
}