using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Module.Tautulli.Models
{
    /// <summary>
    /// Model for the get_library_user_stats-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_library_user_stats" />
    [Measurement("library_user_stats")]
    public class LibraryUserStats
    {
        [JsonProperty("user_id")]
        [Column("user_id", IsTag = true)]
        public int UserId { get; set; }

        [JsonProperty("friendly_name")]
        [Column("friendly_name", IsTag = true)]
        public string Name { get; set; } = default!;

        [JsonProperty("total_plays")]
        [Column("total_plays", IsTag = true)]
        public int TotalPlays { get; set; } = default!;

        [JsonProperty("total_time")]
        [Column("total_time", IsTag = true)]
        public int TotalTime { get; set; } = default!;

        [Column("value")]
        public int Value => UserId;
    };
}