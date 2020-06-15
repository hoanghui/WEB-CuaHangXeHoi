using EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyStore.Models;
using ViewModels;

namespace ToyStore.Controllers
{
    public class ProductsController : Controller
    {
        EntityDataContext _context = new EntityDataContext();
        // GET: Products
        public ActionResult Index()
        {

            var list = (from x in _context.Xe
                        from l in _context.LoaiXe
                        where x.MaLoaiXe == l.MaLoaiXe && x.TrangThai == true
                        select new ProductsViewModel
                        {
                            MaXe = x.MaXe,
                            TenXe = x.TenXe,
                            NamSanXuat = x.NamSanXuat,
                            Gia = x.Gia,
                            MaLoaiXe = x.MaLoaiXe,
                            TenLoaiXe = l.TenLoaiXe
                        }).ToList();
            ViewBag.Quantity = 0;
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductsViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Gia != null && model.NamSanXuat != null && model.TenXe != null )
                {
                    var x = new Xe
                    {
                        TenXe = model.TenXe,
                        NamSanXuat = model.NamSanXuat,
                        MaLoaiXe = model.MaLoaiXe,
                        Gia = model.Gia,
                        TrangThai = true
                    };
                    _context.Xe.Add(x);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }            
            }
            SetViewBag();
            return View();
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.MaLoaiXe = new SelectList(dao.ListAll(), "MaLoaiXe", "TenLoaiXe", selectedId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Xe x = _context.Xe.Find(id);
            ProductsViewModel p = new ProductsViewModel{ 
                MaXe = x.MaXe,
                TenXe = x.TenXe,
                Gia = x.Gia,
                NamSanXuat = x.NamSanXuat,
                MaLoaiXe = x.MaLoaiXe,
                TenLoaiXe = x.TenXe
            };
            SetViewBag(x.MaLoaiXe);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Xe x)
        {
            if (ModelState.IsValid)
            {
                x.TrangThai = true;
                _context.Entry(x).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(x);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Xe x = _context.Xe.Find(id);
            x.TrangThai = false;
            _context.Entry(x).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}