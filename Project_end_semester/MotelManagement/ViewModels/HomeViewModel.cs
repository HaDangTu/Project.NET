using MotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManagement.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public Room Room { get; set; }
    }
}