using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManagement.ViewModels
{
    public class PowerDebt
    {
        [Column("id")]
        public string ID { get; set; }

        [Column("name")]
        [Display(Name = "Tên phòng")]
        public string Name { get; set; }

        [Column("debt")]
        [Display(Name = "Số tiền nợ")]
        public double Debt { get; set; }

        [Column("date")]
        [Display(Name = "Ngày")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column("electric_indicator")]
        [Display(Name = "Chỉ số điện")]
        public long ElectricIndicator { get; set; }

        [Column("water_indicator")]
        [Display(Name = "Chỉ số nước")]
        public long WaterIndicator { get; set; }

        [Column("content")]
        [Display(Name = "Nội dung thu")]
        public string Content { get; set; }

        public double ElectricPara { get; set; }
        public double WaterPara { get; set; }

        public long OldElectricIndicator { get; set; }

        
    }
}