using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    [Table("Guests")]
    public class Guest
    {
        [Column("id")]
        [Required]
        public string ID { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Họ tên")]
        [StringLength(255, ErrorMessage = "{0} tối thiểu {2} kí tự", MinimumLength = 2)]
        //TODO: Add validation name not contain number and special letter
        public string Name { get; set; }

        [Column("birthday")]
        [Required]
        [Display(Name = "Ngày sinh")]
        //TODO: Add validation birthday only contain number
        public string Birthday { get; set; }

        [Column("gender_id")]
        [Required]
        public string GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        [Column("identity_card_number")]
        [Display(Name = "Số CMND")]
        [StringLength(10, ErrorMessage = "{0} tối thiểu {2} số", MinimumLength = 9)]
        public string IDentityCardNumber { get; set; }

        [Column("home_town")]
        [Display(Name = "Quê quán")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(50, ErrorMessage = "{0} tối thiểu {2} kí tự", MinimumLength = 5)]
        public string HomeTown { get; set; }

        [Column("occupation")]
        [Display(Name = "Nghề nghiệp")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(50, ErrorMessage = "{0} tối thiểu {2} kí tự", MinimumLength = 5)]
        public string Occupation { get; set; }

        [Column("start_date")]
        [Display(Name = "Ngày bắt đầu ở")]
        [Required(ErrorMessage = "Vui lòng  nhập {0}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Column("room_id")]
        [Display(Name = "Phòng")]
        [Required]
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }

        [Column("state_id")]
        [Display(Name = "Trạng thái")]
        [Required]
        public string StateID { get; set; }
        public virtual State State { get; set; }

        
    }
}