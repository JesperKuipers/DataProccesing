using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataProccesingAPI.Models
{
    [Table("games_daily", Schema = "datasetsteam")]
    public class games_daily
    {
        [Required]
        [Range(typeof(Int64), "10000000000000000", "99999999999999999", ErrorMessage = "SteamID must be 17 digits")]
        public Int64 steamid { get; set; }
        [Required]
        public Int64 appid { get; set; }
        public Int64? playtime_2weeks { get; set; } //Time in minutes
        public Int64? playtime_forever { get; set; } //Time in minutes
        [DataType(DataType.DateTime)]
        public DateTime? dateretrieved { get; set; }
    }
}
