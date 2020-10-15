using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPham_WebAPP.Models
{
    public class HoaDon
    {
        public string ID_HoaDon { get; set; }
        public string ID_ChiTiet { get; set; }
        public Nullable<System.DateTime> Thoi_Gian { get; set; }
    }
}