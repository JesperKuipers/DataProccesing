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
        [Required]
        public Int64 appid { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Type { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Release_Date { get; set; }
        [Range(-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [Required]
        public int Rating { get; set; }
        [Required]
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
