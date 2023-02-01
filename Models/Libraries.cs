using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_libraries-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_libraries" />
    [Measurement("libraries")]
    public class Libraries
    {
        [JsonProperty("section_id")]
        [Column("section_id", IsTag = true)]
        public string SectionId { get; set; } = default!;

        [JsonProperty("section_name")]
        [Column("section_name", IsTag = true)]
        public string SectionName { get; set; } = default!;

        [JsonProperty("section_type")]
        [Column("section_type", IsTag = true)]
        public string SectionType { get; set; } = default!;

        [JsonProperty("child_count")]
        [Column("child_count", IsTag = true)]
        public string ChildCount { get; set; } = default!;

        [JsonProperty("count")]
        [Column("count", IsTag = true)]
        public string Count { get; set; } = default!;

        [JsonProperty("is_active")]
        [Column("is_active", IsTag = true)]
        public int Active { get; set; } = default!;

        [Column("value")]
        public string Value => SectionId;
    }
}