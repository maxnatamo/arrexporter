using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_activity-command.
    /// The model represents the 'sessions' object in the response.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_activity" />
    [Measurement("session")]
    public class Session
    {
        [JsonProperty("user")]
        [Column("user", IsTag = true)]
        public string User { get; set; } = default!;

        [JsonProperty("progress_percent")]
        [Column("progress_percent", IsTag = true)]
        public string Progress { get; set; } = default!;

        [JsonProperty("media_type")]
        [Column("media_type", IsTag = true)]
        public string MediaType { get; set; } = default!;

        [JsonProperty("section_id")]
        [Column("section_id", IsTag = true)]
        public string SectionId { get; set; } = default!;

        [JsonProperty("library_name")]
        [Column("library_name", IsTag = true)]
        public string LibraryName { get; set; } = default!;

        [JsonProperty("full_title")]
        [Column("full_title", IsTag = true)]
        public string FullTitle { get; set; } = default!;

        [JsonProperty("title")]
        [Column("title", IsTag = true)]
        public string Title { get; set; } = default!;

        [JsonProperty("parent_title")]
        [Column("parent_title", IsTag = true)]
        public string ParentTitle { get; set; } = default!;

        [JsonProperty("grandparent_title")]
        [Column("grandparent_title", IsTag = true)]
        public string GrandparentTitle { get; set; } = default!;

        [JsonProperty("duration")]
        [Column("duration", IsTag = true)]
        public string Duration { get; set; } = default!;

        [JsonProperty("state")]
        [Column("state", IsTag = true)]
        public string State { get; set; } = default!;

        [Column("value")]
        public string Value => User;
    }
}