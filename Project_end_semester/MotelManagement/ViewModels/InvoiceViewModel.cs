using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MotelManagement.Models;
namespace MotelManagement.ViewModels
{
    public class InvoiceViewModel
    {
        [Required]
        [Display(Name = "Từ ngày")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Required]
        [Display(Name = "Đến ngày")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        [Required]
        [Display(Name = "Ngày thu tiền")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CollectionDate { get; set; }

        [Required]
        [Display(Name = "Phòng")]
        public string RoomID { get; set; }
        public string RoomName { get; set; }

        [Display(Name = "Chỉ số cũ")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string ElectricOldIndicator { get; set; }

        [Display(Name = "Chỉ số mới")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string ElectricNewIndicator { get; set; }

        [Display(Name = "Tổng điện năng tiêu thụ")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string SumElectricUsage { get; set; }

        [Display(Name = "Thành tiền")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string ElectricMoney { get; set; }

        [Display(Name = "Chỉ số cũ")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string WaterOldIndicator { get; set; }

        [Display(Name = "Chỉ số mới")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string WaterNewIndicator { get; set; }

        [Display(Name = "Tổng lượng nước tiêu thụ")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string SumWaterUsage { get; set; }

        [Display(Name = "Thành tiền")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string WaterMoney { get; set; }

        [Display(Name = "Tổng số tiền")]
        public string SumMoney { get; set; }

        
        [Display(Name = "Nợ trước")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string PreviousDebt { get; set; }

        [Required]
        [Display(Name = "Còn nợ")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string Debt { get; set; }

        [Required]
        [Display(Name = "Số tiền thu ")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string Proceeds { get; set; }

        [Required]
        [Display(Name = "Số tiền thừa")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public string ExcessCash { get; set; }
    }
}