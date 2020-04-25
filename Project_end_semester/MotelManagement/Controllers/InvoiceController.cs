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

namespace MotelManagement.Controllers
{
    public class InvoiceController : Controller
    {
        private ApplicationDbContext _dbContext;

        public InvoiceController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: CollectPowerInvoice
        public ActionResult CollectRoomInvoice()
        {
            InvoiceViewModel viewModel = new InvoiceViewModel()
            {
                //Lấy danh sách phòng có người ở
                Rooms = _dbContext.Rooms.Include(r => r.RoomType)
                    .Include(r => r.Guests)
                    .Include(r => r.Invoices)
                    .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0)
            };

            //Lấy phòng đang cho thuê đầu tiên
            var firstRoom = viewModel.Rooms.FirstOrDefault();

            //Lấy hóa đơn mới nhất của phòng
            var lastInvoice = firstRoom.Invoices.Where(i => i.Content.Contains("phòng")).LastOrDefault();
            
            if (lastInvoice != null)
            {
                viewModel.FromDate = lastInvoice.ToDate;
                viewModel.ToDate = lastInvoice.ToDate.AddMonths(1);
            }
            else
            {
                viewModel.FromDate = firstRoom.Guests.Where(g => g.StateID == "S01").Min(g => g.StartDate);
                viewModel.ToDate = viewModel.FromDate.AddMonths(1);
            }

            viewModel.Debt = firstRoom.RoomType.Price.ToString("N0");
            viewModel.CollectionDate = DateTime.Now;

            return View(viewModel);
        }

        // POST: CollectPowerInvoice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CollectRoomInvoice(InvoiceViewModel viewModel)
        {
            //generate new Id
            IEnumerable<Invoice> invoices = _dbContext.Invoices;
            var lastInvoice = invoices.LastOrDefault();

            string invoiceId = "I2000000001";
            if (lastInvoice != null) invoiceId = IdGenerator.generateNextID("I", lastInvoice.ID, true);

            //Check infomation is valid
            if (!ModelState.IsValid)
            {
                viewModel.Rooms = _dbContext.Rooms.Include(r => r.RoomType)
                    .Include(r => r.Guests)
                    .Include(r => r.Invoices)
                    .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0);

                return View("CollectRoomInvoice", viewModel);
            }

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
            if (_dbContext.SaveChanges() > 0)
            {
                TempData["Success"] = "Thành công";
                //return View("Print", invoice);
            }
            else
            {
                TempData["Fail"] = "Thất bại";
            }

            return RedirectToAction("CollectRoomInvoice", "Invoice");
        }

        [HttpPost]
        public ActionResult GetRoomDebtInfo(string id)
        {
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();

            InvoiceViewModel viewModel = new InvoiceViewModel()
            {
                //Lấy danh sách phòng có người ở
                Rooms = _dbContext.Rooms.Include(r => r.RoomType)
                    .Include(r => r.Guests)
                    .Include(r => r.Invoices)
                    .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0)
            };

            
            //Lấy phòng theo id
            var room = viewModel.Rooms.Where(r => r.ID == id).SingleOrDefault();

            //Lấy hóa đơn mới nhất của phòng
            var lastInvoice = room.Invoices.Where(i => i.Content.Contains("phòng")).LastOrDefault();

            //Tính toán ngày
            if (lastInvoice != null)
            {
                fromDate = lastInvoice.ToDate;
                
            }
            else //thu tiền phòng lần đầu
            {
                fromDate = room.Guests.Where(g => g.StateID == "S01").Min(g => g.StartDate);
            }

            toDate = fromDate.AddMonths(1);

            //Result result = new Result()
            //{
            //    FromDate = fromDate.ToString("yyyy-MM-dd"),
            //    ToDate = toDate.ToString("yyyy-MM-dd"),
            //    Debt = room.RoomType.Price.ToString("N0")
            //};
            

            viewModel.Debt = room.RoomType.Price.ToString("N0");
            viewModel.CollectionDate = DateTime.Now;

            return RedirectToAction("CollectRoomInvoice", "Invoice", viewModel);
        }

        //GET: Invoice/CollectPowerInvoice
        public ActionResult CollectPowerInvoice()
        {
            InvoiceViewModel viewModel = new InvoiceViewModel()
            {
                //Lấy danh sách các phòng đang cho thuê
                Rooms = _dbContext.Rooms.Include(r => r.RoomType)
                .Include(r => r.Guests)
                .Include(r => r.Invoices)
                .Include(r => r.Infos)
                .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0)
            };

            //lấy phòng đầu tiên 
            var firstRoom = viewModel.Rooms.FirstOrDefault();

            //lấy hóa đơn điện nước mới nhất của phòng
            var lastInvoice = firstRoom.Invoices.Where(i => i.Content.Contains("điện")).LastOrDefault();

            //lấy thông tin chỉ số điện nước (cũ, mới)
            var oldPowerInfo = firstRoom.Infos.Where(i => i.Date.Month == DateTime.Now.Month - 1)
                .SingleOrDefault();
            var newPowerInfo = firstRoom.Infos.Where(i => i.Date.Month == DateTime.Now.Month)
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
            if (lastInvoice != null)
            {
                viewModel.FromDate = lastInvoice.ToDate;
            }
            else
            {
                viewModel.FromDate = firstRoom.Guests.Where(g => g.StateID == "S01")
                    .Min(g => g.StartDate);
            }
            viewModel.ToDate = viewModel.FromDate.AddMonths(1);

            //tính thành tiền điện, nước
            long electricMoney = sumElectricUsage * electricPrice;
            long waterMoney = sumWaterUsage * waterPrice;

            long sumMoney = electricMoney + waterMoney;

            viewModel.Debt = sumMoney.ToString("N0");
            viewModel.CollectionDate = DateTime.Now;

            viewModel.ElectricOldIndicator = oldPowerInfo.ElectricIndicator.ToString("N0");
            viewModel.ElectricNewIndicator = newPowerInfo.ElectricIndicator.ToString("N0");
            viewModel.SumElectricUsage = sumElectricUsage.ToString("N0");
            viewModel.ElectricMoney = electricMoney.ToString("N0");

            viewModel.WaterOldIndicator = oldPowerInfo.WaterIndicator.ToString("N0");
            viewModel.WaterNewIndicator = newPowerInfo.WaterIndicator.ToString("N0");
            viewModel.SumWaterUsage = sumWaterUsage.ToString("N0");
            viewModel.WaterMoney = waterMoney.ToString("N0");
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
                viewModel.Rooms = _dbContext.Rooms.Include(r => r.RoomType)
                    .Include(r => r.Guests)
                    .Include(r => r.Invoices)
                    .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0);

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

            if (_dbContext.SaveChanges() > 0)
            {
                TempData["Success"] = "Thu tiền điện nước thành công";
            }
            else
            {
                TempData["Fail"] = "Thu tiền điện nước thất bại";
            }

            return RedirectToAction("CollectPowerInvoice", "Invoice");
        }

        
        public ActionResult GetPowerOfRoom(string id)
        {
            IEnumerable<Room> rooms = _dbContext.Rooms.Include(r => r.Invoices).Include(r => r.Guests)
                .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0);

            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();

            var room = rooms.Where(r => r.ID == id).SingleOrDefault();

            //Lấy hóa đơn mới nhất của phòng
            var lastInvoice = room.Invoices.Where(i => i.Content.Contains("điện")).LastOrDefault();

            //Tính toán ngày
            if (lastInvoice != null)
            {
                fromDate = lastInvoice.ToDate;

            }
            else //thu tiền phòng lần đầu
            {
                fromDate = room.Guests.Where(g => g.StateID == "S01").Min(g => g.StartDate);
            }

            toDate = fromDate.AddMonths(1);

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

            //tính thành tiền điện, nước
            long electricMoney = sumElectricUsage * electricPrice;
            long waterMoney = sumWaterUsage * waterPrice;

            long sumMoney = electricMoney + waterMoney;

            Result result = new Result()
            {
                FromDate = fromDate.ToString("dd-MM-yyyy"),
                ToDate = toDate.ToString("dd-MM-yyyy"),
                ElectricOldIndicator = oldPowerInfo.ElectricIndicator.ToString("N0"),
                ElectricNewIndicator = newPowerInfo.ElectricIndicator.ToString("N0"),
                SumElectricUsage = sumElectricUsage.ToString("N0"),
                ElectricMoney = electricMoney.ToString("N0"),
                WaterOldIndicator = oldPowerInfo.WaterIndicator.ToString("N0"),
                WaterNewIndicator = newPowerInfo.WaterIndicator.ToString("N0"),
                SumWaterUsage = sumWaterUsage.ToString("N0"),
                WaterMoney = waterMoney.ToString("N0"),
                Debt = sumMoney.ToString("N0")
            };

            return Json(result);
        }
    }

    

    public class Result
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Debt { get; set; }

        public string ElectricOldIndicator { get; set; }
        public string ElectricNewIndicator { get; set; }
        public string SumElectricUsage { get; set; }
        public string ElectricMoney { get; set; }

        public string WaterOldIndicator { get; set; }
        public string WaterNewIndicator { get; set; }
        public string SumWaterUsage { get; set; }
        public string WaterMoney { get; set; }
    }
}