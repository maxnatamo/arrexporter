using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Tautulli.Models
{
    /// <summary>
    /// Model for the get_library_names-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_library_names" />
    [Measurement("library_names")]
    public class LibraryNames
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

        [Column("value")]
        public string Value => SectionId;
    }
}