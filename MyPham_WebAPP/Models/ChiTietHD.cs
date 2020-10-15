using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPham_WebAPP.Models
{
    public class ChiTietHD
    {
        public string ID_Chi_Tiet { get; set; }
        public string ID_SP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> Gia { get; set; }
    }
}