using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataProccesingAPI.Models
{
    [Table("player_summaries", Schema = "datasetsteam")]
    public class player_summaries
    {
#pragma warning disable CS8632 // Question mark is needed, cause these can be empty in the database. This just supresses the mention.
        [Required]
        [Range(typeof(Int64), "10000000000000000", "99999999999999999", ErrorMessage = "SteamID must be 17 digits")]
        public Int64 steamid { get; set; }
        public string? personaname { get; set; }
        public string? profileurl { get; set; }
        public string? avatar { get; set; }
        public string? avatarmedium { get; set; }
        public string? avatarfull { get; set; }
        public Byte? personastate { get; set; }
        public Byte? communityvisibilitystate { get; set; }
        public Byte? profilestate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? lastlogoff { get; set; }
        public Byte? commentpermission { get; set; }
        public string? realname { get; set; }
        public decimal? primaryclanid { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? timecreated { get; set; }
        public Int64? gameid { get; set; }
        public string? gameserverip { get; set; }
        public string? gameextrainfo { get; set; }
        public Int64? cityid { get; set; }
        [MaxLength(3)]
        public string? loccountrycode { get; set; } //ISO-3166 code for the country
        public string? locstatecode { get; set; }
        public Int64? loccityid { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? dateretrieved { get; set; }
#pragma warning restore CS8632 // Question mark is needed, cause these can be empty in the database. This just supresses the mention.
    }
}
