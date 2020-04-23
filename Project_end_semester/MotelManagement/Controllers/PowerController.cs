using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MotelManagement.DAL;
using MotelManagement.ViewModels;
using MotelManagement.Models;
using MotelManagement.Utility;

namespace MotelManagement.Controllers
{
    public class PowerController : Controller
    {
        private ApplicationDbContext _dbContext;

        public PowerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Update Power
        public ActionResult Update()
        {
            PowerInfoViewModel viewModel = new PowerInfoViewModel()
            {
                Rooms = _dbContext.Rooms.Include(i => i.Infos)
                .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0 &&
                    r.Infos.Count(i => i.Date.Month == (DateTime.Now.Month)) < 1)
            };

            return View(viewModel);
        }

        [HttpPost]
        //[Authorize(Roles = "Owner")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PowerInfoViewModel viewModel)
        {
            string nextInfosId = string.Empty;
            IEnumerable<ElectricityAndWaterInfo> infos = _dbContext.Infos;

            var lastInfos = infos.LastOrDefault();

            if (lastInfos == null) nextInfosId = "IEW200001";
            else nextInfosId = IdGenerator.generateNextID("IEW", lastInfos.ID, true);

            if (!ModelState.IsValid)
            {
                PowerInfoViewModel model = new PowerInfoViewModel()
                {
                    Rooms = _dbContext.Rooms.Include(i => i.Infos)
                    .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0 &&
                    r.Infos.Count(i => i.Date.Month == (DateTime.Now.Month)) < 1)
                };

                return View(model);
            }

            ElectricityAndWaterInfo info = new ElectricityAndWaterInfo()
            {
                ID = nextInfosId,
                Date = viewModel.Date,
                ElectricIndicator = viewModel.ElectricIndicator,
                WaterIndicator = viewModel.WaterIndicator,
                RoomID = viewModel.RoomID
            };

            _dbContext.Infos.Add(info);
            if (_dbContext.SaveChanges() > 0)
            {
                TempData["Success"] = "Cập nhật thông tin điện nước thành công";
            }
            else
            {
                TempData["Fail"] = "Cập nhật thông tin điện nước thất bại";
            }
            return RedirectToAction("Update", "Power");
        }
    }
}