using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MotelManagement.Models;

namespace MotelManagement.ViewModels
{
    public class RoomInfoViewModel
    {
        [Display(Name = "Tên phòng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Name { get; set; }

        [Display(Name = "Loại phòng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string TypeID { get; set; }

        public string RoomID { get; set; }
        public IEnumerable<RoomType> RoomTypes { get; set; }
    }
}