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
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        [Key]
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
        public string? loccountrycode { get; set; }
        public string? locstatecode { get; set; }
        public Int64? loccityid { get; set; }
        public DateTime? dateretrieved { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}
