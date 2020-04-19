using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    [Table("ElectricityAndWaterInfos")]
    public class ElectricityAndWaterInfo
    {
        [Column("id")]
        [Required]
        public string ID { get; set; }

        [Column("room_id")]
        [Required]
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }

        [Column("date")]
        [Display(Name = "Ngày")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column("electric_indicator")]
        [Display(Name = "Chỉ số điện")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public long ElectricIndicator { get; set; }

        [Column("water_indicator")]
        [Display(Name = "Chỉ số nước")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public long WaterIndicator { get; set; }
    }
}