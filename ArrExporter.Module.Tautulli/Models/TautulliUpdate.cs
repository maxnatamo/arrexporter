using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Module.Tautulli.Models
{
    /// <summary>
    /// Model for the update-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#update" />
    [Measurement("tautulli_update")]
    public class TautulliUpdate
    {
        [JsonProperty("update")]
        [Column("update", IsTag = true)]
        public bool UpdateAvailable { get; set; }

        [Column("value")]
        public bool Value => UpdateAvailable;
    };
}