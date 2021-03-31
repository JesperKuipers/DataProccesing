using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataProccesingAPI.Models
{
    [Table("games_1", Schema = "datasetsteam")]
    public class games_1
    {
        [Key]
        public Int64 steamid { get; set; }
        public Int64 appid { get; set; }
        public Int64? playtime_2weeks { get; set; }
        public Int64? playtime_forever { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? dateretrieved { get; set; }
    }
}
