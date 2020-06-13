using EntityModels;
using System;
using System.Collections.Generic;
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
                        select new CategoryViewModel
                        {
                                MaLoaiXe = l.MaLoaiXe,
                                TenLoaiXe = l.TenLoaiXe
                        });
            ViewBag.Quantity = 0;
            return View(list);
        }

    }
}