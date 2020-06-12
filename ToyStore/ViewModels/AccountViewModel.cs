using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AccountViewModel
    {
        [Required,Display(Name = "Tên đăng nhập")]
        public string TenQuanLy { get; set; }

        [Required,Display(Name = "Mật khẩu")]
        public string PassQuanLy { get; set; }
    }
}
