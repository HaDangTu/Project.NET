﻿using System;
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
        public ActionResult Index()
        {
            var RoomType = _dbContext.RoomTypes;
            return View(RoomType);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
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

        public ActionResult Edit(String id = "")
        {
            var RoomType = _dbContext.RoomTypes.Where(r => r.ID == id);
            return View(RoomType.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(RoomType RoomTypeModel)
        {
            var room_type = _dbContext.RoomTypes.Single(r => r.ID == RoomTypeModel.ID);
            room_type.Name = RoomTypeModel.Name;
            room_type.NumberOfGuest = RoomTypeModel.NumberOfGuest;
            room_type.Price = RoomTypeModel.Price;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String id = "")
        {
            var RoomType = _dbContext.RoomTypes.Where(r => r.ID == id);
            return View(RoomType.FirstOrDefault());
        }

        public ActionResult Delete(String id = "")
        {
            var RoomType = _dbContext.RoomTypes.Where(r => r.ID == id);
            return View(RoomType.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(RoomType RoomTypeModel)
        {
            var RoomType = _dbContext.RoomTypes.FirstOrDefault(r => r.ID == RoomTypeModel.ID);
            _dbContext.RoomTypes.Remove(RoomType);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}