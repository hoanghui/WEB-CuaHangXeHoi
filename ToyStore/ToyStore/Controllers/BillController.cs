using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace ToyStore.Controllers
{
    public class BillController : Controller
    {
        EntityDataContext _context = new EntityDataContext();
        // GET: Bill
        public ActionResult Index()
        {
            var list = (from hd in _context.HoaDon
                        where hd.TrangThai == true
                        select new BillViewModel
                        {
                            MaHoaDon = hd.MaHoaDon,
                            NgayLapHoaDon = hd.NgayLapHoaDon,
                            ThanhToan = hd.ThanhToan,
                            MaKhachHang = hd.MaKhachHang
                        }).ToList();
            ViewBag.Quantity = 0;
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            
            HoaDon h = _context.HoaDon.Find(id);
            var master = (from hd in _context.HoaDon
                        join chitiet in _context.HoaDon.Include("Xe") on hd.MaHoaDon equals chitiet.MaHoaDon
                        join kh in _context.KhachHang on hd.MaKhachHang equals kh.MaKhachHang
                        where hd.MaHoaDon == id
                        select new BillViewModel
                        {
                            MaHoaDon = h.MaHoaDon,
                            NgayLapHoaDon = h.NgayLapHoaDon,
                            ThanhToan = h.ThanhToan,
                            MaKhachHang = h.MaKhachHang,
                            HoTenKhachHang = kh.HoTenKhachHang,
                            NgaySinh = kh.NgaySinh,
                            DiaChi = kh.DiaChi,
                            
                            DanhSachChiTiet =  chitiet.Xe.Select(p => new DetailBillViewModel() { 
                                MaXe = p.MaXe,
                                TenXe = p.TenXe,
                                Gia = p.Gia,
                                NamSanXuat = p.NamSanXuat,
                                TenLoaiXe = _context.LoaiXe.Where(o=>o.MaLoaiXe == p.MaLoaiXe).Select(o=>o.TenLoaiXe).FirstOrDefault()
                            }).ToList()
                        }).FirstOrDefault();
            ViewBag.Quantity = 0;
            var tong = master.DanhSachChiTiet.Select(p => p.Gia).Sum();
            var tongHoaDon = master.ThanhToan;
            var temp = tongHoaDon - tong;
            double thue = Double.Parse(temp.ToString());
            ViewBag.Thue = thue;
            return View(master);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            HoaDon hd = _context.HoaDon.Find(id);
            hd.TrangThai = false;
            _context.Entry(hd).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}