using MotelManagement.DAL;
using MotelManagement.Models;
using MotelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MotelManagement.Controllers
{

    public class ReportController : Controller
    {
        // GET: Report
        private ApplicationDbContext _dbContext;

        DateTime fd;
        DateTime td;

        //private string Room_ID = "R0001";
        public ReportController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize(Roles = "Owner")]
        public ActionResult IncomingStatementReport(string FromDate, string ToDate)
        {
            if (FromDate != null & ToDate != null)
            {
                fd = DateTime.Parse(FromDate);
                td = DateTime.Parse(ToDate);
            }
            var model = _dbContext.Invoices.Where(x => x.CollectionDate >= fd && x.CollectionDate <= td).ToList();
            ViewBag.Summary = SummaryProceed(model);

            return View(model);

        }

        public double SummaryProceed(IEnumerable<Invoice> model)
        {
            double summary = 0;
            foreach (var item in model)
            {
                summary += item.Proceeds;
            }
            return summary;
        }

        [Authorize(Roles = "Guest")]
        public ActionResult RoomDebtInfos(string id)
        {
            string Room_ID = id;
            var model = _dbContext.Invoices.Where(x => x.Debt > 0 && x.RoomID == Room_ID && x.Content.Contains("Tiền phòng")).ToList();
            ViewBag.RoomName = ReturnRoomName(Room_ID);
            return View(model);
        }

        public string ReturnRoomName(string Roomid)
        {
            var model = _dbContext.Rooms.Where(x => x.ID == Roomid).SingleOrDefault();
            return model.Name;
        }

        [Authorize(Roles = "Guest")]
        public ActionResult PowerDebtInfos(string id)
        {
            string Room_ID = id;
            double electricpara, waterpara;
            electricpara = GetParameter(1);
            waterpara = GetParameter(0);

            var model = (from i in _dbContext.Invoices
                         join r in _dbContext.Rooms on i.RoomID equals r.ID
                         join e in _dbContext.Infos on new { RoomID = i.RoomID, Month = i.CollectionDate.Month, Year = i.CollectionDate.Year } equals
                                                         new { RoomID = e.RoomID, Month = e.Date.Month, Year = e.Date.Year }
                         where i.Debt > 0 && i.Content.Contains("điện nước") && r.ID == Room_ID
                         select new PowerDebt
                         {
                             ID = i.RoomID,
                             Name = r.Name,
                             Debt = i.Debt,
                             Content = i.Content,
                             Date = e.Date,
                             ElectricIndicator = e.ElectricIndicator,
                             WaterIndicator = e.WaterIndicator,
                             ElectricPara = electricpara,
                             WaterPara = waterpara,
                         }).ToList();

            ViewBag.RoomName = ReturnRoomName(Room_ID);
            return View(model);
        }

        private double GetParameter(int type)
        {
            if (type == 1)
            {

                return Double.Parse(_dbContext.Parameters.Where(p => p.Name == "Giá điện")
                .SingleOrDefault().Value);
            }
            else
            {

                return Double.Parse(_dbContext.Parameters.Where(p => p.Name == "Giá nước")
                    .SingleOrDefault().Value); ;
            }
        }

        [Authorize(Roles = "Owner")]
        public ActionResult ReportDebt()
        {
            var powermodel = (from r in _dbContext.Rooms
                              join i in _dbContext.Invoices on r.ID equals i.RoomID
                              where i.Debt > 0 && i.Content.Contains("điện nước")
                              group r by new { r.ID, r.Name } into grp
                              select new AllPowerDebtViewModel
                              {
                                  CountDebt = grp.Count(),
                                  ID = grp.Key.ID,
                                  Name = grp.Key.Name
                              });
            var roommodel = (from r in _dbContext.Rooms
                             join i in _dbContext.Invoices on r.ID equals i.RoomID
                             where i.Debt > 0 && i.Content.Contains("phòng")
                             group r by new { r.ID, r.Name } into grp
                             select new AllRoomDebtViewModel
                             {
                                 CountDebt = grp.Count(),
                                 ID = grp.Key.ID,
                                 Name = grp.Key.Name
                             });
            DebtViewModels model = new DebtViewModels();
            model.allPowerDebts = powermodel;
            model.allRoomDebts = roommodel;

            return View(model);
        }


    }
}