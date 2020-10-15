using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPham_WebAPP.Models
{
    public class TaiKhoan
    {
        public string ID { get; set; }
        public string Ten_DN { get; set; }
        public string MatKhau { get; set; }
        public Nullable<int> Cap { get; set; }
    }
}