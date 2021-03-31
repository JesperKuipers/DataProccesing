using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataProccesingAPI.Models
{
    [Table("achievement_percentages", Schema = "datasetsteam")]
    public class achievement_percentages
    {
        [Key]
        [Required]
        public Int64 appid { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public float Percentage { get; set; }
}
}
