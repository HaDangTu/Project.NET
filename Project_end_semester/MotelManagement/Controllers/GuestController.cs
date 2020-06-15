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
using PagedList;
using System.Reflection;

namespace MotelManagement.Controllers
{
    public class GuestController : Controller
    {
        private ApplicationDbContext _dbContext;
        public GuestController()
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
            var viewModel = _dbContext.Guests.Include(r => r.Gender).Include(r => r.Room);

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
            var viewModel = new GuestInfoViewModel
            {
                Genders = _dbContext.Genders.ToList(),
                Rooms = _dbContext.Rooms.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Create(GuestInfoViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewModel.Genders = _dbContext.Genders.ToList();
                ViewModel.Rooms = _dbContext.Rooms.ToList();
                return View("Create", ViewModel);
            }

            string nextInfosId = string.Empty;
            IEnumerable<Guest> listguest = _dbContext.Guests;

            var lastGuest = listguest.LastOrDefault();

            if (lastGuest == null) nextInfosId = "G000001";
            else nextInfosId = IdGenerator.generateNextID("G", lastGuest.ID, false);

            var guest = new Guest
            {
                ID = nextInfosId,
                Name = ViewModel.Name,
                Birthday = ViewModel.Birthday,
                GenderId = ViewModel.GenderID,
                IDentityCardNumber = ViewModel.IDentityCardNumber,
                HomeTown = ViewModel.HomeTown,
                Occupation = ViewModel.Occupation,
                RoomID = ViewModel.RoomID,
                StateID = "S01"
            };
            _dbContext.Guests.Add(guest);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Edit(String id = "")
        {
            Guest guest = _dbContext.Guests.Where(r => r.ID == id).Include(r => r.Gender).Include(r => r.Room).SingleOrDefault();
            var viewModel = new GuestInfoViewModel
            {
                GuestID = guest.ID,
                Name = guest.Name,
                Birthday = guest.Birthday,
                Occupation = guest.Occupation,
                IDentityCardNumber = guest.IDentityCardNumber,
                HomeTown = guest.HomeTown,
                GenderID = guest.GenderId,
                RoomID = guest.RoomID,
                Genders = _dbContext.Genders.ToList(),
                Rooms = _dbContext.Rooms.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Edit(GuestInfoViewModel ViewModel)
        {
            var guest = _dbContext.Guests.Single(r => r.ID == ViewModel.GuestID);
            guest.Name = ViewModel.Name;
            guest.Birthday = ViewModel.Birthday;
            guest.Occupation = ViewModel.Occupation;
            guest.HomeTown = ViewModel.HomeTown;
            guest.IDentityCardNumber = ViewModel.IDentityCardNumber;
            guest.GenderId = ViewModel.GenderID;
            guest.RoomID = ViewModel.RoomID;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner, Guest")]
        public ActionResult Details(String id = "")
        {
            IEnumerable<Guest> viewModel = _dbContext.Guests.Include(r => r.Gender).Include(r => r.Room).Where(r => r.ID == id);
            return View(viewModel.FirstOrDefault());
        }
        [Authorize(Roles = "Owner")]
        public ActionResult Delete(String id = "")
        {
            IEnumerable<Guest> viewModel = _dbContext.Guests.Include(r => r.Gender).Include(r => r.Room).Where(r => r.ID == id);
            return View(viewModel.FirstOrDefault());
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Delete(Guest Guest)
        {
            var guest = _dbContext.Guests.FirstOrDefault(r => r.ID == Guest.ID);
            _dbContext.Guests.Remove(guest);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}