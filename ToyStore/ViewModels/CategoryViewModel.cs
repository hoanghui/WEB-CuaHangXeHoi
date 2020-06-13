using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Mã loại xe")]
        public int MaLoaiXe { get; set; }
        [Display(Name = "Tên loại xe")]
        public string TenLoaiXe { get; set; }

        public virtual ICollection<Xe> Xe { get; set; }
    }
}
