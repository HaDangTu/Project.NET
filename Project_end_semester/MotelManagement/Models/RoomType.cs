using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    public class RoomType
    {
        [Required]
        [Column("id")]
        public string ID { get; set; }

        [Column("name")]
        [Display(Name = "Tên loại phòng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Name { get; set; }

        [Column("number_of_guest")]
        [Display(Name = "Số lượng khách trọ")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Range(1, 8, ErrorMessage = "{0} từ {1} đến {2}")]
        //TODO Add validation if numberOfGuest contain letter or special letter
        public int NumberOfGuest { get; set; }

        [Column("price")]
        [Display(Name = "Giá thuê phòng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Range(1000000, 100000000, ErrorMessage ="{0} phải trên {1:N0} VND")]
        public double Price { get; set; }


        public virtual ICollection<Room> Rooms { get; set; }

        
    }
}