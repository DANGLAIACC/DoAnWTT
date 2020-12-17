using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tiki.ViewModel
{
    public class BookDetailVM
    {
        public int Book_id { get; set; }
        public string Book_name { get; set; }
        public string Book_img { get; set; }
        public int? Book_price { get; set; }
        public int? Book_sale { get; set; }
        public DateTime? Public_date { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public int? Page_number { get; set; }
        public string Cover_type { get; set; }
        public string Article { get; set; }
        public string Translator { get; set; }
        public string Aut_name { get; set; }
        public string Com_name { get; set; }
        public string Pub_name { get; set; }
        public string Cat_name { get; set; }
        public string Shop_name{ get; set; }

        public int[] arrRateNumber { get; set; }
        public List<EVALUATE> Evaluates { get; set; }

    }
}