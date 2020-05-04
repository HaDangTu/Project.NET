using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotelManagement.DAL;
using MotelManagement.Models;
using MotelManagement.Utility;

namespace MotelManagement.Controllers
{
    public class RoomTypeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public RoomTypeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: RoomType
        [Authorize(Roles = "Owner")]
        public ActionResult Index()
        {
            var RoomType = _dbContext.RoomTypes;
            return View(RoomType);
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                var links = _dbContext.RoomTypes
                    .Where(s => s.Name.Contains(searchString)); //lọc theo chuỗi tìm kiếm
                return View(links); //trả về kết quả
            }
            var viewModel = _dbContext.RoomTypes;
            return View(viewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Create(RoomType RoomTypeModel)
        {
            string nextInfosId = string.Empty;
            IEnumerable<RoomType> roomtype = _dbContext.RoomTypes;

            var lastRoomType = roomtype.LastOrDefault();

            if (lastRoomType == null) nextInfosId = "T01";
            else nextInfosId = IdGenerator.generateNextID("T", lastRoomType.ID, false);
            var room_type = new RoomType
            {
                ID = nextInfosId,
                Name = RoomTypeModel.Name,
                NumberOfGuest = RoomTypeModel.NumberOfGuest,
                Price = RoomTypeModel.Price
            };
            _dbContext.RoomTypes.Add(room_type);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Edit(String id = "")
        {
            var RoomType = _dbContext.RoomTypes.Where(r => r.ID == id);
            return View(RoomType.FirstOrDefault());
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Edit(RoomType RoomTypeModel)
        {
            var room_type = _dbContext.RoomTypes.Single(r => r.ID == RoomTypeModel.ID);
            room_type.Name = RoomTypeModel.Name;
            room_type.NumberOfGuest = RoomTypeModel.NumberOfGuest;
            room_type.Price = RoomTypeModel.Price;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Details(String id = "")
        {
            var RoomType = _dbContext.RoomTypes.Where(r => r.ID == id);
            return View(RoomType.FirstOrDefault());
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Delete(String id = "")
        {
            var RoomType = _dbContext.RoomTypes.Where(r => r.ID == id);
            return View(RoomType.FirstOrDefault());
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Delete(RoomType RoomTypeModel)
        {
            var RoomType = _dbContext.RoomTypes.FirstOrDefault(r => r.ID == RoomTypeModel.ID);
            _dbContext.RoomTypes.Remove(RoomType);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}