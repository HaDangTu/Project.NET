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

            return View(rooms );
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
    }
}