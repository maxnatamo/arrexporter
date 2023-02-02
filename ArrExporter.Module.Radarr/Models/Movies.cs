using Newtonsoft.Json;
using InfluxDB.Client.Core;

using ArrExporter.Shared.Converters;

namespace ArrExporter.Module.Radarr.Models
{
    /// <summary>
    /// Model for the /api/v3/movie endpoint.
    /// </summary>
    /// <seealso href="https://radarr.video/docs/api/#/Movie/get_api_v3_movie" />
    [Measurement("movies")]
    [JsonConverter(typeof(JsonPathConverter))]
    public class Movies
    {
        [JsonProperty("added")]
        [Column("added", IsTag = true)]
        public string Added { get; set; } = default!;

        [JsonProperty("certification", NullValueHandling = NullValueHandling.Ignore)]
        [Column("certification", IsTag = true)]
        public string Certification { get; set; } = default!;

        [JsonProperty("digitalRelease")]
        [Column("digitalRelease", IsTag = true)]
        public string DigitalRelease { get; set; } = default!;

        [JsonProperty("folderName")]
        [Column("folderName", IsTag = true)]
        public string FolderName { get; set; } = default!;

        [JsonProperty("hasFile")]
        [Column("hasFile", IsTag = true)]
        public bool HasFile { get; set; } = default!;

        [JsonProperty("id")]
        [Column("id", IsTag = true)]
        public int Id { get; set; } = default!;

        [JsonProperty("imdbId")]
        [Column("imdbId", IsTag = true)]
        public string ImdbId { get; set; } = default!;

        [JsonProperty("inCinemas", NullValueHandling = NullValueHandling.Ignore)]
        [Column("inCinemas", IsTag = true)]
        public string InCinemas { get; set; } = default!;

        [JsonProperty("isAvailable")]
        [Column("isAvailable", IsTag = true)]
        public bool IsAvailable { get; set; } = default!;

        [JsonProperty("minimumAvailability")]
        [Column("minimumAvailability", IsTag = true)]
        public string MinimumAvailability { get; set; } = default!;

        [JsonProperty("monitored")]
        [Column("monitored", IsTag = true)]
        public bool Monitored { get; set; } = default!;

        [JsonProperty("physicalRelease", NullValueHandling = NullValueHandling.Ignore)]
        [Column("physicalRelease", IsTag = true)]
        public string PhysicalRelease { get; set; } = default!;

        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        [Column("popularity", IsTag = true)]
        public float Popularity { get; set; } = default!;

        [JsonProperty("runtime")]
        [Column("runtime", IsTag = true)]
        public int Runtime { get; set; } = default!;

        [JsonProperty("sizeOnDisk", NullValueHandling = NullValueHandling.Ignore)]
        [Column("sizeOnDisk", IsTag = true)]
        public UInt64 SizeOnDisk { get; set; } = default!;

        [JsonProperty("status")]
        [Column("status", IsTag = true)]
        public string Status { get; set; } = default!;

        [JsonProperty("studio", NullValueHandling = NullValueHandling.Ignore)]
        [Column("studio", IsTag = true)]
        public string Studio { get; set; } = default!;

        [JsonProperty("title")]
        [Column("title", IsTag = true)]
        public string Title { get; set; } = default!;

        [JsonProperty("tmdbId")]
        [Column("tmdbId", IsTag = true)]
        public string TmdbId { get; set; } = default!;

        [JsonProperty("year")]
        [Column("year", IsTag = true)]
        public int Year { get; set; } = default!;

        /**
         * Nested object: 'movieFile'.
         * All variables are nullable, as a file may not exist.
         */

        [JsonProperty("movieFile.dateAdded")]
        [Column("fileAdded", IsTag = true)]
        public string? FileAdded { get; set; } = null;

        /**
         * Nested object: 'movieFile.mediaInfo'.
         * All variables are nullable, as a file may not exist.
         */

        [JsonProperty("movieFile.mediaInfo.audioBitrate")]
        [Column("fileResolution", IsTag = true)]
        public int? AudioBitrate { get; set; } = null;

        [JsonProperty("movieFile.mediaInfo.audioChannels")]
        [Column("audioChannels", IsTag = true)]
        public int? AudioChannels { get; set; } = null;

        [JsonProperty("movieFile.mediaInfo.audioCodec")]
        [Column("audioCodec", IsTag = true)]
        public string? AudioCodec { get; set; } = null;

        [JsonProperty("movieFile.mediaInfo.resolution")]
        [Column("fileResolution", IsTag = true)]
        public string? Resolution { get; set; } = null;

        [JsonProperty("movieFile.mediaInfo.scanType")]
        [Column("scanType", IsTag = true)]
        public string? ScanType { get; set; } = null;

        [JsonProperty("movieFile.mediaInfo.videoBitDepth")]
        [Column("videoBitDepth", IsTag = true)]
        public string? VideoBitDepth { get; set; } = null;

        [JsonProperty("movieFile.mediaInfo.videoBitrate")]
        [Column("videoBitrate", IsTag = true)]
        public UInt64? VideoBitrate { get; set; } = null;

        [JsonProperty("movieFile.mediaInfo.videoFps")]
        [Column("videoFramerate", IsTag = true)]
        public int? VideoFramerate { get; set; } = null;

        /**
         * Nested object: 'movieFile.quality'.
         * All variables are nullable, as a file may not exist.
         */

        [JsonProperty("movieFile.quality.quality.name")]
        [Column("qualityName", IsTag = true)]
        public string? QualityName { get; set; } = null;

        [JsonProperty("movieFile.quality.quality.resolution")]
        [Column("qualityResolution", IsTag = true)]
        public int? QualityResolution { get; set; } = null;

        [JsonProperty("movieFile.quality.quality.source")]
        [Column("qualitySource", IsTag = true)]
        public string? QualitySource { get; set; } = null;

        [Column("value")]
        public int Value => Id;
    }
}