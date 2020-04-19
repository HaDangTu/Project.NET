using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MotelManagement.Models;

namespace MotelManagement.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ElectricityAndWaterInfo> Infos { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}