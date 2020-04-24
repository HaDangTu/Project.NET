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
        public IEnumerable<Room> Rooms { get; set; }

        [Required]
        [Display(Name = "Tổng số tiền")]
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