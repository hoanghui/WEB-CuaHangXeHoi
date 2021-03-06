﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductsViewModel
    {   
        [Display(Name ="Mã xe")]
        public int MaXe { get; set; }

        [Display(Name = "Tên xe")]
        public string TenXe { get; set; }

        [Display(Name = "Năm sản xuất")]
        public Nullable<int> NamSanXuat { get; set; }

        [Display(Name = "Giá xe"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0,0}")]
        public Nullable<double> Gia { get; set; }

        [Display(Name = "Mã loại xe")]
        public Nullable<int> MaLoaiXe { get; set; }

        [Display(Name = "Tên loại xe")]
        public string TenLoaiXe{ get; set; }

    }
}
