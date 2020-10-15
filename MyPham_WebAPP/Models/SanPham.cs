using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPham_WebAPP.Models
{
    public class SanPham
    {
        public string ID_SP { get; set; }
        public string ID_Loai { get; set; }
        public string Ten_SP { get; set; }
        public string HinhAnh { get; set; }
        public string ThuongHieu { get; set; }
        public Nullable<int> So_Luong { get; set; }
        public string Mota { get; set; }
        public string NoiDung { get; set; }
    }
}