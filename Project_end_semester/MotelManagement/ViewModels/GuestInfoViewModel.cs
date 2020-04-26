using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MotelManagement.Models;

namespace MotelManagement.ViewModels
{
    public class GuestInfoViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Họ tên")]
        [StringLength(255, ErrorMessage = "{0} tối thiểu {2} kí tự", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ngày sinh")]
        public String Birthday { get; set; }

        [Display(Name = "Số CMND")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(10, ErrorMessage = "{0} tối thiểu {2} số", MinimumLength = 9)]
        public string IDentityCardNumber { get; set; }

        [Display(Name = "Quê quán")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(50, ErrorMessage = "{0} tối thiểu {2} kí tự", MinimumLength = 5)]
        public string HomeTown { get; set; }

        [Display(Name = "Nghề nghiệp")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(50, ErrorMessage = "{0} tối thiểu {2} kí tự", MinimumLength = 5)]
        public string Occupation { get; set; }

        [Display(Name = "Phòng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string RoomID { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public string GenderID { get; set; }

        public string GuestID { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Gender> Genders { get; set; }

    }
}