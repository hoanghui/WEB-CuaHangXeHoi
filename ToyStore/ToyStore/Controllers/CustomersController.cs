﻿using EntityModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace ToyStore.Controllers
{
    public class CustomersController : Controller
    {
        EntityDataContext _context = new EntityDataContext();

        // GET: Customers
        public ActionResult Index()
        {
            var list = (from kh in _context.KhachHang
                        where kh.TrangThai == true
                        select new CustomerViewModel
                        {
                            MaKhachHang = kh.MaKhachHang,
                            HoTenKhachHang = kh.HoTenKhachHang,
                            NgaySinh = kh.NgaySinh,
                            DiaChi = kh.DiaChi,
                            DanhSachHoaDon = _context.HoaDon.Where(o => o.MaKhachHang == kh.MaKhachHang).Select(p=>p.MaHoaDon).Count<int>() 
                        }) ;
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
            if (c.HoTenKhachHang != null || c.NgaySinh != null || c.DiaChi != null)
            {
                var kh = new KhachHang
                {
                    MaKhachHang = c.MaKhachHang,
                    HoTenKhachHang = c.HoTenKhachHang,
                    NgaySinh = c.NgaySinh,
                    DiaChi = c.DiaChi,
                    TrangThai = true,

                };
                _context.KhachHang.Add(kh);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            KhachHang kh = _context.KhachHang.Find(id);
            return View(kh);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                kh.TrangThai = true;
                _context.Entry(kh).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kh);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            KhachHang kh = _context.KhachHang.Find(id);
            kh.TrangThai = false;
            _context.Entry(kh).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}