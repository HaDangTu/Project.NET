using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using MotelManagement.DAL;
using MotelManagement.Models;
using MotelManagement.ViewModels;

namespace MotelManagement.Controllers
{
    public class InvoiceApiController : ApiController
    {
        private ApplicationDbContext _dbContext;
        
        public InvoiceApiController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IHttpActionResult GetRoomInvoice(string roomId)
        {
            //Lấy ra danh sách các phòng đang cho thuê
            IEnumerable<Room> rooms = _dbContext.Rooms.Include(r => r.RoomType)
                .Include(r => r.Invoices)
                .Include(r => r.Guests)
                .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0);

            //Lấy phòng theo ID
            var room = rooms.Where(r => r.ID == roomId).SingleOrDefault();

            //Lấy hóa đơn tiền phòng mới nhất của phòng
            var lastInvoice = room.Invoices.Where(i => i.Content.Contains("phòng")).LastOrDefault();

            InvoiceViewModel viewModel = new InvoiceViewModel();

            //Tính ngày trên hóa đơn
            if (lastInvoice != null)
            {
                viewModel.FromDate = lastInvoice.ToDate;
            }
            else
            {
                viewModel.FromDate = room.Guests.Where(g => g.StateID == "S01").Min(g => g.StartDate);
            }

            viewModel.ToDate = viewModel.FromDate.AddMonths(1);
            viewModel.Debt = room.RoomType.Price.ToString("N0");
            viewModel.CollectionDate = DateTime.Now;

            return Ok(viewModel);
        }
    }
}
