using EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace ToyStore.Controllers
{
    public class CategoryController : Controller
    {
        EntityDataContext _context = new EntityDataContext();
        // GET: Category
        public ActionResult Index()
        {
            var list = (from l in _context.LoaiXe
                        where l.TrangThai == true
                        select new CategoryViewModel
                        {
                            MaLoaiXe = l.MaLoaiXe,
                            TenLoaiXe = l.TenLoaiXe
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
        public ActionResult Create(CategoryViewModel c)
        {
            if (c.TenLoaiXe != null)
            {
                var l = new LoaiXe
                {
                    TenLoaiXe = c.TenLoaiXe,
                    TrangThai = true
                };
                _context.LoaiXe.Add(l);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LoaiXe lx = _context.LoaiXe.Find(id);
            return View(lx);
        }

        [HttpPost]
        public ActionResult Edit(LoaiXe lx)
        {
            if (ModelState.IsValid)
            {
                lx.TrangThai = true;
                _context.Entry(lx).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lx);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            LoaiXe lx = _context.LoaiXe.Find(id);
            lx.TrangThai = false;
            _context.Entry(lx).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}