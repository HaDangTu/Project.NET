using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    [Table("States")]
    public class State
    {
        [Column("id")]
        [Required]
        public string ID { get; set; }

        [Column("name")]
        [Display(Name = "Tên giới tính")]
        [Required]
        public string Name { get; set; }

        public IEnumerable<Guest> Guests { get; set; }
    }
}