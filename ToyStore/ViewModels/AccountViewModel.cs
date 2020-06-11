using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    class AccountViewModel
    {
        public int TenQuanLy { get; set; }
        [Display(Name = "Tên đăng nhập")]

        public string MatKhau { get; set; }
    }
}
