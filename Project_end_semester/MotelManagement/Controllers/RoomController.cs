using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using MotelManagement.DAL;
using MotelManagement.ViewModels;
using MotelManagement.Models;
using MotelManagement.Utility;
using System.Web.Routing;
using PagedList;
using System.Reflection;

namespace MotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private ApplicationDbContext _dbContext;
        public RoomController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public class HttpParamActionAttribute : ActionNameSelectorAttribute
        {
            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                if (actionName.Equals(methodInfo.Name, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                var request = controllerContext.RequestContext.HttpContext.Request;
                return request[methodInfo.Name] != null;
            }
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Index(int? size, int? page, string searchString)
        {
            // Tạo biến ViewBag gồm  searchValue và page
            ViewBag.searchValue = searchString;
            ViewBag.page = page;

            // Tạo danh sách chọn số trang
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "15", Value = "15" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "30", Value = "30" });

            // Thiết lập số trang đang chọn vào danh sách
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            ViewBag.size = items;
            ViewBag.currentSize = size;

            //  Truy vấn lấy tất cả đường dẫn
            var viewModel = _dbContext.Rooms.Include(r => r.RoomType);

            //  Thêm phần tìm kiếm
            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel = viewModel.Where(s => s.Name.Contains(searchString));
            }
            viewModel = viewModel.OrderBy(r => r.Name);
            //  Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            //  Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            ViewBag.pageSize = pageSize;

            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber. --- dammio.com
            int pageNumber = (page ?? 1);

            // Lấy tổng số record chia cho kích thước để biết bao nhiêu trang
            int checkTotal = (int)(viewModel.ToList().Count / pageSize) + 1;
            // Nếu trang vượt qua tổng số trang thì thiết lập là 1 hoặc tổng số trang
            if (pageNumber > checkTotal) pageNumber = checkTotal;

            return View(viewModel.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Owner")]
        public ActionResult Create()
        {
            var viewModel = new RoomInfoViewModel
            {
                RoomTypes = _dbContext.RoomTypes.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Create(RoomInfoViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewModel.RoomTypes = _dbContext.RoomTypes.ToList();
                return View("Create", ViewModel);
            }
            string nextInfosId = string.Empty;
            IEnumerable<Room> listroom = _dbContext.Rooms;

            var lastRoom = listroom.LastOrDefault();

            if (lastRoom == null) nextInfosId = "R0001";
            else nextInfosId = IdGenerator.generateNextID("R", lastRoom.ID, false);

            var room = new Room
            {
                ID = nextInfosId,
                Name = ViewModel.Name,
                RoomTypeID = ViewModel.TypeID,
                UserID = null
            };
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Edit(String id = "")
        {
            Room room = _dbContext.Rooms.Where(r => r.ID == id).Include(r => r.RoomType).SingleOrDefault();
            var viewModel = new RoomInfoViewModel
            {
                RoomID = room.ID,
                Name = room.Name,
                TypeID = room.RoomTypeID,
                RoomTypes = _dbContext.RoomTypes.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Edit(RoomInfoViewModel ViewModel)
        {
            var room = _dbContext.Rooms.Single(r => r.ID == ViewModel.RoomID);
            room.Name = ViewModel.Name;
            room.RoomTypeID = ViewModel.TypeID;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Details(String id = "")
        {
            IEnumerable<Room> viewModel = _dbContext.Rooms.Include(r => r.RoomType).Where(r => r.ID == id);
            return View(viewModel.FirstOrDefault());
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Delete(String id = "")
        {
            IEnumerable<Room> viewModel = _dbContext.Rooms.Include(r => r.RoomType).Where(r => r.ID == id);
            return View(viewModel.FirstOrDefault());
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Delete(Room Room)
        {
            var room = _dbContext.Rooms.FirstOrDefault(r => r.ID == Room.ID);
            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner")]
        public ActionResult RoomDetail(string id)
        {
            IEnumerable<Room> rooms = _dbContext.Rooms.Include(r => r.RoomType)
                .Include(r => r.Guests);

            Room room = rooms.Where(r => r.ID == id).SingleOrDefault();
            if (room == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(room);
        }
        //public ActionResult AdvancedSearch()
        //{
        //    var viewModel = new RoomInfoViewModel
        //    {
        //        RoomTypes = _dbContext.RoomTypes.ToList()
        //    };
        //    return View(viewModel);
        //}
        //[HttpPost]
        //public ActionResult AdvancedSearch(RoomInfoViewModel ViewModel)
        //{
        //    return RedirectToAction("Index",
        //        new RouteValueDictionary(new { Controller = "Room", Action = "Index", viewmodel = ViewModel }));
        //}
    }
}