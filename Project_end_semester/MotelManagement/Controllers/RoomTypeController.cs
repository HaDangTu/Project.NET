using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotelManagement.DAL;
using MotelManagement.Models;
using MotelManagement.Utility;
using PagedList;
using System.Reflection;

namespace MotelManagement.Controllers
{
    public class RoomTypeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public RoomTypeController()
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
            var viewModel = _dbContext.RoomTypes.OrderBy(r => r.Name);
            //  Thêm phần tìm kiếm
            if (!String.IsNullOrEmpty(searchString))
                viewModel = _dbContext.RoomTypes.Where(s => s.Name.Contains(searchString)).OrderBy(r => r.Name);
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