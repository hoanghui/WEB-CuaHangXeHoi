using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyStore.Models
{
    public class CategoryDAO
    {
        EntityDataContext _context = null;

        public CategoryDAO()
        {
            _context = new EntityDataContext();
        }

        public List<LoaiXe> ListAll()
        {
            return _context.LoaiXe.ToList();
        }
    }
}