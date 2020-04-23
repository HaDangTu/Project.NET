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
    public class PowerController : Controller
    {
        //Thuộc tính để lấy data trong database lên
        private ApplicationDbContext _dbContext;

        public PowerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        /* GET: Power/Update
         * 
         */
        public ActionResult Update()
        {
            /* Sử dụng viewmodel/model tại đây đều được
             * nếu model thông thường không đáp ứng được dữ liệu để show trên view thì sử dụng view model
             * vd trên form thêm một học sinh cần phải có dữ liệu để fill vào combox lớp đê người dùng chọn lớp cho học sinh
             * thì ta tạo StudentViewModel có thuộc tính List<Course> Courses để có thể fill data vào combobox
             */ 
            PowerInfoViewModel viewModel = new PowerInfoViewModel()
            {
                /* Sử dụng LINQ đê lọc ra những phòng chưa đc cập nhật chỉ số điện, nước
                 */
                Rooms = _dbContext.Rooms.Include(i => i.Infos)
                .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0 &&
                    r.Infos.Count(i => i.Date.Month == (DateTime.Now.Month)) < 1) 
            };

            /*
             * Lưu ý: Khi chúng ta dùng viewModel thì kết quả khi submit form sẽ trả về là 1 viewModel 
             * (Xem tham số của phương thức xử lý POST request bên dưới)
             */ 
            return View(viewModel);
        }

        /*  Post: Update Power
         *  Request của client khi nhấn nút submit trên form sẽ đc xử lý tại phương thức này
         *  ViewModel/Model sẽ lưu những thông tin mà người dùng đã nhập trên form của page.
         */
        [HttpPost]
        //[Authorize(Roles = "Owner")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PowerInfoViewModel viewModel)
        {
            //Tạo next Id
            string nextInfosId = string.Empty;
            IEnumerable<ElectricityAndWaterInfo> infos = _dbContext.Infos;

            var lastInfos = infos.LastOrDefault();

            if (lastInfos == null) nextInfosId = "IEW200001";
            else nextInfosId = IdGenerator.generateNextID("IEW", lastInfos.ID, true);

            //Kiểm tra các trường trên form đã valid hay không
            if (!ModelState.IsValid)
            {
                PowerInfoViewModel model = new PowerInfoViewModel()
                {
                    Rooms = _dbContext.Rooms.Include(i => i.Infos)
                    .Where(r => r.Guests.Count(g => g.StateID == "S01") > 0 &&
                    r.Infos.Count(i => i.Date.Month == (DateTime.Now.Month)) < 1)
                };

                return View(model);
            }

            //Mapping dữ liệu trên form
            ElectricityAndWaterInfo info = new ElectricityAndWaterInfo()
            {
                ID = nextInfosId,
                Date = viewModel.Date,
                ElectricIndicator = viewModel.ElectricIndicator,
                WaterIndicator = viewModel.WaterIndicator,
                RoomID = viewModel.RoomID
            };

            /* Insert dữ liệu vào database
             * Sử dụng _dbContext.SaveChanges() để lưu lại các thay đổi trên CSDL (Insert, Update, Delete)
             */
            _dbContext.Infos.Add(info);
            if (_dbContext.SaveChanges() > 0)
            {
                TempData["Success"] = "Cập nhật thông tin điện nước thành công";
            }
            else
            {
                TempData["Fail"] = "Cập nhật thông tin điện nước thất bại";
            }

            //Redirect về home page hoặc bất cứ page nào mình muốn
            return RedirectToAction("Update", "Power");
        }
    }
}