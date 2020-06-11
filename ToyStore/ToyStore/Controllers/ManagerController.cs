using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace ToyStore.Controllers
{
    public class ManagerController : Controller
    {
        EntityDataContext _context = new EntityDataContext();

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            var list = (from s in _context.KhachHang
                        select new CustomerViewModel
                        {
                            MaKhachHang = s.MaKhachHang,
                            HoTenKhachHang = s.HoTenKhachHang,
                            NgaySinh = s.NgaySinh,
                            DiaChi = s.DiaChi
                        });
            ViewBag.Quantity = 0;
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerViewModel c)
        {
            if ( c.HoTenKhachHang != null || c.NgaySinh != null || c.DiaChi != null)
            {
                var kh = new KhachHang
                {
                    MaKhachHang = c.MaKhachHang,
                    HoTenKhachHang = c.HoTenKhachHang,
                    NgaySinh = c.NgaySinh,
                    DiaChi = c.DiaChi
                };
                _context.KhachHang.Add(kh);
                _context.SaveChanges();
            }
            return RedirectToAction("Customers");
        }
    }
}