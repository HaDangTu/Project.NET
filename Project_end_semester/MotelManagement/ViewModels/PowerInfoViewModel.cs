using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MotelManagement.Models;

namespace MotelManagement.ViewModels
{
    public class PowerInfoViewModel
    {
        [Required]
        [Display(Name = "Ngày")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Chỉ số điện")]
        public int ElectricIndicator { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Chỉ số nước")]
        public int WaterIndicator { get; set; }

        public string RoomID { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}