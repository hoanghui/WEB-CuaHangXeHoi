using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name ="Mã số")]
        public int MaKhachHang { get; set; }

        [Display(Name = "Họ tên khách hàng")]
        public string  HoTenKhachHang { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime?  NgaySinh { get; set; }
        [Display(Name = "Địa chỉ")]
        public string   DiaChi{ get; set; }
       
    }
}
