using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Tautulli.Models
{
    /// <summary>
    /// Model for the get_user_names-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_user_names" />
    [Measurement("usernames")]
    public class Usernames
    {
        [JsonProperty("user_id")]
        [Column("user_id", IsTag = true)]
        public int UserId { get; set; }

        [JsonProperty("friendly_name")]
        [Column("friendly_name", IsTag = true)]
        public string Name { get; set; } = default!;

        [Column("value")]
        public int Value => UserId;
    };
}