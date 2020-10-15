using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPham_WebAPP.Models
{
    public class GiaBan
    {
        public string ID_GB { get; set; }
        public string ID_SP { get; set; }
        public Nullable<int> Gia_KM { get; set; }
        public Nullable<System.DateTime> TG_BD { get; set; }
        public Nullable<System.DateTime> TG_KT { get; set; }
    }
}