using Newtonsoft.Json;

namespace ArrExporter.Tautulli.Models
{
    /// <summary>
    /// Base response for all Tautulli API queries.
    /// </summary>
    public class TautulliResponse
    {
        public class InnerResponse
        {
            [JsonProperty("result")]
            public string Result { get; set; } = default!;

            [JsonProperty("message")]
            public string? Message { get; set; } = null;

            [JsonProperty("data")]
            public dynamic? Data { get; set; } = null;
        }

        [JsonProperty("response")]
        public InnerResponse Response { get; set; } = default!;
    }
}