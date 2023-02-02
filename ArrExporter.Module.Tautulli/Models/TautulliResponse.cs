using Newtonsoft.Json;

using ArrExporter.Shared.Converters;

namespace ArrExporter.Module.Tautulli.Models
{
    /// <summary>
    /// Base response for all Tautulli API queries.
    /// </summary>
    [JsonConverter(typeof(JsonPathConverter))]
    public class TautulliResponse
    {
        [JsonProperty("response.result")]
        public string Result { get; set; } = default!;

        [JsonProperty("response.message")]
        public string? Message { get; set; } = null;

        [JsonProperty("response.data")]
        public dynamic? Data { get; set; } = null;
    }
}