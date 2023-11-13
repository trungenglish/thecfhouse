using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thecfhouse.Models
{
    public class ProductViewModel
    {
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public int? MALOAIHANG { get; set; }
        public string HINHSP { get; set; }
        public string MOTA { get; set; }
        public decimal? GIA { get; set; }
    }
}