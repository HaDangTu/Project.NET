using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    [Table("Genders")]
    public class Gender
    {
        [Required]
        [Column("id")]
        public string ID { get; set; }

        [Column("name")]
        [Required]
        [Display(Name = "Tên giới tính")]
        public string Name { get; set; }

        public virtual IEnumerable<Guest> Guests { get; set; }
    }
}