using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    [Table("Rooms")]
    public class Room
    { 
        [Column("id")]
        [Required]
        public string ID { get; set; }
        
        [Column("name")]
        [Display(Name = "Tên phòng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Name { get; set; }

        [Column("room_type_id")]
        [Display(Name = "Loại phòng")]
        [Required]
        public string RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        [Column("user_id")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual IEnumerable<Invoice> Invoices { get; set; }

        public virtual IEnumerable<ElectricityAndWaterInfo> Infos { get; set; }

        public virtual IEnumerable<Guest> Guests { get; set; }
    }
}