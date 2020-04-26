using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MotelManagement.Models;
using MotelManagement.ViewModels;
using MotelManagement.DAL;
using MotelManagement.Utility;
using System.Net;

namespace MotelManagement.Controllers
{
    public class InvoiceController : Controller
    {
        private ApplicationDbContext _dbContext;

        public InvoiceController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            IEnumerable<Room> rooms = _dbContext.Rooms.Include(r => r.RoomType)
                .Include(r => r.Infos)
                .Include(r => r.Invoices)
                .Include(r => r.Guests)
                .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0);

            return View(rooms);    
        }

        // GET: CollectPowerInvoice
        public ActionResult CollectRoomInvoice(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            var room = _dbContext.Rooms.Where(r => r.ID == id).SingleOrDefault();

            //Lấy hóa đơn mới nhất của phòng
            var lastInvoice = room.Invoices.Where(i => i.Content.Contains("phòng")).LastOrDefault();

            //Tính date time
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();

            if (lastInvoice != null)
            {
                fromDate = lastInvoice.ToDate;
                toDate = lastInvoice.ToDate.AddMonths(1);
            }
            else //phòng mới được thuê lần đầu
            {
                fromDate = room.Guests.Where(g => g.StateID == "S01").Min(g => g.StartDate);
                toDate = fromDate.AddMonths(1);
            }

            InvoiceViewModel viewModel = new InvoiceViewModel()
            {
                RoomID = id,
                RoomName = room.Name,
                FromDate = fromDate,
                ToDate = toDate,
                CollectionDate = DateTime.Now,
                Debt = room.RoomType.Price.ToString("N0"),
                Proceeds = "0",
                ExcessCash = "0"
            };
            
            return View(viewModel);
        }

        // POST: CollectPowerInvoice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CollectRoomInvoice(string id, InvoiceViewModel viewModel)
        {
            //Check infomation is valid
            if (!ModelState.IsValid)
            {
                return View("CollectRoomInvoice", viewModel);
            }

            //generate new Id
            IEnumerable<Invoice> invoices = _dbContext.Invoices;
            var lastInvoice = invoices.LastOrDefault();

            string invoiceId = "I2000000001";
            if (lastInvoice != null) invoiceId = IdGenerator.generateNextID("I", lastInvoice.ID, true);

            //Mapping data
            Invoice invoice = new Invoice()
            {
                ID = invoiceId,
                RoomID = viewModel.RoomID,
                FromDate = viewModel.FromDate,
                ToDate = viewModel.ToDate,
                CollectionDate = viewModel.CollectionDate,
                Content = "Tiền phòng tháng " + viewModel.FromDate.Month,
                Debt = double.Parse(viewModel.Debt),
                Proceeds = double.Parse(viewModel.Proceeds),
                ExcessCash = double.Parse(viewModel.ExcessCash)
            };

            //Save invoice
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Invoice");
        }


        //GET: Invoice/CollectPowerInvoice
        public ActionResult CollectPowerInvoice(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var room = _dbContext.Rooms.Where(r => r.ID == id).SingleOrDefault();

            //lấy hóa đơn điện nước mới nhất của phòng
            var lastInvoice = room.Invoices.Where(i => i.Content.Contains("điện")).LastOrDefault();

            //lấy thông tin chỉ số điện nước (cũ, mới)
            var oldPowerInfo = room.Infos.Where(i => i.Date.Month == DateTime.Now.Month - 1)
                .SingleOrDefault();
            var newPowerInfo = room.Infos.Where(i => i.Date.Month == DateTime.Now.Month)
                .SingleOrDefault();

            long sumElectricUsage = newPowerInfo.ElectricIndicator - oldPowerInfo.ElectricIndicator;
            long sumWaterUsage = newPowerInfo.WaterIndicator - oldPowerInfo.WaterIndicator;

            //lấy giá tiền 1kwh điện và 1 m3 nước
            int electricPrice = int.Parse(_dbContext.Parameters.Where(p => p.Name == "Giá điện")
                .SingleOrDefault().Value);

            int waterPrice = int.Parse(_dbContext.Parameters.Where(p => p.Name == "Giá nước")
                .SingleOrDefault().Value);

            //tính thời gian (từ ngày, đến ngày), thành tiền điện, thành tiền nước, tổng tiền phải đóng
            //tính thời gian (từ ngày, đến ngày)
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();

            if (lastInvoice != null)
            {
                fromDate = lastInvoice.ToDate;
            }
            else
            {
                fromDate = room.Guests.Where(g => g.StateID == "S01")
                    .Min(g => g.StartDate);
            }
            toDate = fromDate.AddMonths(1);

            //tính thành tiền điện, nước
            long electricMoney = sumElectricUsage * electricPrice;
            long waterMoney = sumWaterUsage * waterPrice;

            long sumMoney = electricMoney + waterMoney;

            InvoiceViewModel viewModel = new InvoiceViewModel()
            {
                RoomID = id,
                RoomName = room.Name,
                FromDate = fromDate,
                ToDate = toDate,
                CollectionDate = DateTime.Now,
                ElectricOldIndicator = oldPowerInfo.ElectricIndicator.ToString("N0"),
                ElectricNewIndicator = newPowerInfo.ElectricIndicator.ToString("N0"),
                SumElectricUsage = sumElectricUsage.ToString("N0"),
                ElectricMoney = electricMoney.ToString("N0"),
                WaterOldIndicator = oldPowerInfo.WaterIndicator.ToString("N0"),
                WaterNewIndicator = newPowerInfo.WaterIndicator.ToString("N0"),
                SumWaterUsage = sumWaterUsage.ToString("N0"),
                WaterMoney = waterMoney.ToString("N0"),
                Debt = sumMoney.ToString("N0"),
                Proceeds = "0",
                ExcessCash = "0"
            };
            
            return View(viewModel);

        }

        //POST: Invoice/CollectPowerInvoice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CollectPowerInvoice(InvoiceViewModel viewModel)
        {
            //Check infomation is valid
            if (!ModelState.IsValid)
            {
                return View("CollectPowerInvoice", viewModel);
            }

            //generate next id
            IEnumerable<Invoice> invoices = _dbContext.Invoices;
            string nextId = string.Empty;
            var lastInvoice = invoices.LastOrDefault();

            if (lastInvoice == null) nextId = "I2000000001";
            else nextId = IdGenerator.generateNextID("I", lastInvoice.ID, true);

            Invoice invoice = new Invoice()
            {
                ID = nextId,
                RoomID = viewModel.RoomID,
                FromDate = viewModel.FromDate,
                ToDate = viewModel.ToDate,
                CollectionDate = viewModel.CollectionDate,
                Content = "Tiền điện nước tháng " + viewModel.FromDate.Month,
                Debt = double.Parse(viewModel.Debt),
                Proceeds = double.Parse(viewModel.Proceeds),
                ExcessCash = double.Parse(viewModel.ExcessCash)
            };

            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Invoice");
        }
    }

    //public class Result
    //{
    //    public string FromDate { get; set; }
    //    public string ToDate { get; set; }
    //    public string Debt { get; set; }

    //    public string ElectricOldIndicator { get; set; }
    //    public string ElectricNewIndicator { get; set; }
    //    public string SumElectricUsage { get; set; }
    //    public string ElectricMoney { get; set; }

    //    public string WaterOldIndicator { get; set; }
    //    public string WaterNewIndicator { get; set; }
    //    public string SumWaterUsage { get; set; }
    //    public string WaterMoney { get; set; }
    //}
}