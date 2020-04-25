using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    [Table("Parameters")]
    public class Parameter
    {
        [Column("id")]
        [Required]
        public string ID { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("type")]
        [Required]
        public string Type { get; set; } //bool, int, float, double

        [Column("value")]
        [Required]
        public string Value { get; set; }

        [Column("state")]
        [Required]
        public bool State { get; set; }
    }
}