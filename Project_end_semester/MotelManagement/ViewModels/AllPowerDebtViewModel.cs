using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManagement.ViewModels
{
    public class AllPowerDebtViewModel
    {
        public int CountDebt { get; set; }

        [Column("id")]
        public string ID { get; set; }

        [Column("name")]
        [Display(Name = "Tên phòng")]
        public string Name { get; set; }
    }
}