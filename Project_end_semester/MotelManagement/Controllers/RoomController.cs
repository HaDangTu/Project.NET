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

namespace MotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private ApplicationDbContext _dbContext;
        public RoomController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Room
        public ActionResult Index()
        {
            IEnumerable<Room> viewModel = _dbContext.Rooms.Include(r => r.RoomType);
            return View(viewModel);
        }
        //[Authorize(Roles = "Owner")]
        public ActionResult Create()
        {
            var viewModel = new RoomInfoViewModel
            {
                RoomTypes = _dbContext.RoomTypes.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        //[Authorize(Roles = "Owner")]
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
        //[Authorize(Roles = "Owner")]
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
        //[Authorize(Roles = "Owner")]
        public ActionResult Edit(RoomInfoViewModel ViewModel)
        {
            var room = _dbContext.Rooms.Single(r => r.ID == ViewModel.RoomID);
            room.Name = ViewModel.Name;
            room.RoomTypeID = ViewModel.TypeID;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Owner")]
        public ActionResult Details(String id = "")
        {
            IEnumerable<Room> viewModel = _dbContext.Rooms.Include(r => r.RoomType).Where(r => r.ID == id);
            return View(viewModel.FirstOrDefault());
        }
        //[Authorize(Roles = "Owner")]
        public ActionResult Delete(String id = "")
        {
            IEnumerable<Room> viewModel = _dbContext.Rooms.Include(r => r.RoomType).Where(r => r.ID == id);
            return View(viewModel.FirstOrDefault());
        }
        [HttpPost]
        //[Authorize(Roles = "Owner")]
        public ActionResult Delete(Room Room)
        {
            var room = _dbContext.Rooms.FirstOrDefault(r => r.ID == Room.ID);
            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Owner")]
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
    }
}