using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataProccesingAPI.Models
{
    [Table("app_id_info", Schema = "datasetsteam")]
    public class app_id_info
    {
        [Key]
        public Int64 appid { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Release_Date { get; set; }
        public int Rating { get; set; }
        public int Required_Age { get; set; }
        public int? Is_Multiplayer { get; set; }
        [NotMapped]
        public bool IsMultiplayer
        {
            get => Is_Multiplayer > 0;
            set { this.Is_Multiplayer = (byte)(value ? 1 : 0); }
        }
    }
}
