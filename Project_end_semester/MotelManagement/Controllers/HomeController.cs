using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;
using MotelManagement.DAL;
using MotelManagement.Models;

namespace MotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<Room> rooms = await _dbContext.Rooms.Include(r => r.Guests).ToListAsync();
            
            return View(rooms);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Search(string content)
        {
            IEnumerable<Room> rooms = _dbContext.Rooms.Include(r => r.RoomType)
                .Include(g => g.Guests);
            content = content.ToLower();

            IEnumerable<Room> result;
            if (content.Contains("còn trống"))
            {
                result = rooms.Where(r => Contains(content, r.Name) ||
                  Contains(content, r.RoomType.Name) ||
                  Contains(content, r.RoomType.Price.ToString()) ||
                  r.Guests.Count(g => g.StateID == "S01") == 0);
            }
            else if (content.Contains("không trống") || content.Contains("đủ người"))
            {
                result = rooms.Where(r => Contains(content, r.Name) ||
                  Contains(content, r.RoomType.Name) ||
                  Contains(content, r.RoomType.Price.ToString()) ||
                  r.Guests.Count(g => g.StateID == "S01") == r.RoomType.NumberOfGuest);
            }
            else
            {
                result = rooms.Where(r => Contains(content, r.Name) ||
                       Contains(content, r.RoomType.Name) ||
                       Contains(content, r.RoomType.Price.ToString()));
            }


            return View("Index", result);
        }

        private bool Contains(string value1, string value2)
        {
            if (value1.Length > value2.Length)
                return value1.ToLower().Contains(value2.ToLower());
            else
                return value2.ToLower().Contains(value1.ToLower());
        }
    }
}