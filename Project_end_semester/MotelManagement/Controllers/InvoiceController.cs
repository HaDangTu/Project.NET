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
                //Lấy những phòng chưa thanh toán hóa đơn tháng hiện tại
                Rooms = _dbContext.Rooms.Include(r => r.RoomType)
                    .Include(r => r.Guests)
                    .Include(r => r.Invoices)
                    .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0)
            };

            //Lấy phòng đang cho thuê đầu tiên
            var firstRoom = viewModel.Rooms.Where(r => r.Guests.Count(g => g.StateID == "S01") > 0)
                .FirstOrDefault();

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

        public ActionResult GetRoomDebtInfo(string id)
        {
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();

            IEnumerable<Room> rooms = _dbContext.Rooms.Include(r => r.Invoices).Include(r => r.Guests)
                .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0);
            //Lấy phòng theo id
            var room = rooms.Where(r => r.ID == id).SingleOrDefault();

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

            Result result = new Result()
            {
                FromDate = fromDate.ToString("yyyy-MM-dd"),
                ToDate = toDate.ToString("yyyy-MM-dd"),
                Debt = room.RoomType.Price.ToString("N0")
            };

            return Json(result);
        }
    }

    public class Result
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Debt { get; set; }
    }
}