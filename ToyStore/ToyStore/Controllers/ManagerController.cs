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
    public class ManagerController : Controller
    {
        EntityDataContext _context = new EntityDataContext();

        // GET: Manager

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AccountViewModel a)
        {
            var list = (from s in _context.QuanLy
                        where (a.TenQuanLy == s.TenQuanLy && a.PassQuanLy == s.PassQuanLy)
                        select s.TenQuanLy
                        ).ToList();

            if (a.TenQuanLy != null && a.PassQuanLy != null)
            {
                if (list.Count() == 1)
                {
                    ViewBag.Name = a.TenQuanLy.ToString();
                    return View("Home");                }
            }
            return View("Index");
        }

        public ActionResult Home()
        {
            return View();
        }


        
    }
}