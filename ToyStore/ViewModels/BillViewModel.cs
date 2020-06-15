using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BillViewModel
    {
        [Display(Name = "Mã hóa đơn")]
        public int MaHoaDon { get; set; }

        [Display(Name = "Ngày lập hóa đơn"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime NgayLapHoaDon { get; set; }

        [Display(Name = "Tổng tiền"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0,0}")]
        public Nullable<double> ThanhToan { get; set; }

        [Display(Name = "Mã khách hàng")]
        public Nullable<int> MaKhachHang { get; set; }

        [Display(Name = "Họ tên khách hàng")]
        public string HoTenKhachHang { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public List<DetailBillViewModel> DanhSachChiTiet { get; set; }
    }
}
