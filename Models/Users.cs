using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_user-command.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_user" />
    [Measurement("users")]
    public class Users
    {
        [JsonProperty("allow_guest")]
        [Column("allow_guest", IsTag = true)]
        public int AllowGuest { get; set; } = default!;

        [JsonProperty("deleted_user")]
        [Column("deleted_user", IsTag = true)]
        public int DeletedUser { get; set; } = default!;

        [JsonProperty("do_notify")]
        [Column("do_notify", IsTag = true)]
        public int DoNotify { get; set; } = default!;

        [JsonProperty("email")]
        [Column("email", IsTag = true)]
        public string Email { get; set; } = default!;

        [JsonProperty("friendly_name")]
        [Column("friendly_name", IsTag = true)]
        public string Name { get; set; } = default!;

        [JsonProperty("is_active")]
        [Column("is_active", IsTag = true)]
        public int IsActive { get; set; } = default!;

        [JsonProperty("is_admin")]
        [Column("is_admin", IsTag = true)]
        public int IsAdmin { get; set; } = default!;

        [JsonProperty("is_allow_sync")]
        [Column("is_allow_sync", IsTag = true)]
        public int IsAllowSync { get; set; } = default!;

        [JsonProperty("is_home_user")]
        [Column("is_home_user", IsTag = true)]
        public int IsHomeUser { get; set; } = default!;

        [JsonProperty("is_restricted")]
        [Column("is_restricted", IsTag = true)]
        public int IsRestricted { get; set; } = default!;

        [JsonProperty("keep_history")]
        [Column("keep_history", IsTag = true)]
        public int KeepHistory { get; set; } = default!;

        [JsonProperty("last_seen")]
        [Column("last_seen", IsTag = true)]
        public int LastSeen { get; set; } = default!;

        [JsonProperty("row_id")]
        [Column("row_id", IsTag = true)]
        public int RowId { get; set; } = default!;
        
        [JsonProperty("user_id")]
        [Column("user_id", IsTag = true)]
        public int UserId { get; set; } = default!;
        
        [JsonProperty("username")]
        [Column("username", IsTag = true)]
        public string Username { get; set; } = default!;

        [Column("value")]
        public int Value => UserId;
    };
}