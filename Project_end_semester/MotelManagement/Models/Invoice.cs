using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotelManagement.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [Column("id")]
        [Required]
        public string ID { get; set; }

        [Column("room_id")]
        [Required]
        [Display(Name = "Phòng")]
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }

        [Column("from_date")]
        [Display(Name = "Từ ngày")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Column("to_date")]
        [Display(Name = "Đến ngày")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        [Column("collection_date")]
        [Display(Name = "Ngày thu tiền")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime CollectionDate { get; set; }

        [Column("content")]
        [Display(Name = "Nội dung thu")]
        [Required]
        [StringLength(255, ErrorMessage = "{0} không hợp lệ")]
        public string Content { get; set; }

        [Column("debt")]
        [Display(Name = "Số tiền nợ")]
        [Required]
        public double Debt { get; set; }

        [Column("proceeds")]
        [Display(Name = "Số tiền thu")]
        [Required]
        public double Proceeds { get; set; }

        [Column("excess_cash")]
        [Display(Name = "Số tiền thừa")]
        [Required]
        public double ExcessCash { get; set; }
    }
}