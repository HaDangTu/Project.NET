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
        /* Chứa các thuộc tính dùng để truy vấn dữ liệu với database, 
         * mỗi thuộc tính vd Genders tương đương với một bảng trong database vd bảng Genders
         * Khi cần truy vấn dữ liệu chỉ cần gọi đến các thuộc tính này hoặc có thể sử dung LINQ để lọc dữ liệu
         * Khi tạo ra một model mới mà model này tương đương với 1 bảng trong CSDL thì thêm model vào đây rồi sử dụng
         * Add-Migration trong Package Console Manager. EF6 sẽ tự động viết lệnh tạo bảng, sau đó sd lệnh Update-Database 
         * để tạo bảng mới trong CSDL
         */
        public DbSet<Gender> Genders { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ElectricityAndWaterInfo> Infos { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

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