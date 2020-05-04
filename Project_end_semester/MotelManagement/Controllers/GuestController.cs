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
    public class GuestController : Controller
    {
        private ApplicationDbContext _dbContext;
        public GuestController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Guest
        //[Authorize(Roles = "Owner")]
        public ActionResult Index()
        {
            IEnumerable<Guest> viewModel = _dbContext.Guests.Include(r => r.Gender).Include(r => r.Room);
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                var links = _dbContext.Guests.Include(r => r.Gender).Include(r => r.Room)
                    .Where(s => s.Name.Contains(searchString)); //lọc theo chuỗi tìm kiếm
                return View(links); //trả về kết quả
            }
            IEnumerable<Guest> viewModel = _dbContext.Guests.Include(r => r.Gender).Include(r => r.Room);
            return View(viewModel);
        }
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
        [Authorize(Roles = "Owner")]
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