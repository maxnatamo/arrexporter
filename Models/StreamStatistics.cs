using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_activity-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_activity" />
    [Measurement("stream_stats")]
    public class StreamStatistics
    {
        [JsonProperty("stream_count")]
        [Column("stream_count", IsTag = true)]
        public int StreamCount { get; set; }

        [JsonProperty("stream_count_direct_play")]
        [Column("stream_count_direct_play", IsTag = true)]
        public int StreamCountDirectPlay { get; set; }

        [JsonProperty("stream_count_direct_stream")]
        [Column("stream_count_direct_stream", IsTag = true)]
        public int StreamCountDirectStream { get; set; }

        [JsonProperty("stream_count_transcode")]
        [Column("stream_count_transcode", IsTag = true)]
        public int StreamCountTranscode { get; set; }

        [JsonProperty("total_bandwidth")]
        [Column("total_bandwidth", IsTag = true)]
        public int TotalBandwidth { get; set; }

        [JsonProperty("wan_bandwidth")]
        [Column("wan_bandwidth", IsTag = true)]
        public int WanBandwidth { get; set; }

        [JsonProperty("lan_bandwidth")]
        [Column("lan_bandwidth", IsTag = true)]
        public int LanBandwidth { get; set; }

        [Column("value")]
        public int Value => StreamCount;
    };
}