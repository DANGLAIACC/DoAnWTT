using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tiki.Models
{
    public class BookDelete
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
        public int? Aut_id { get; set; }
        public int? Com_id { get; set; }
        public int? Pub_id { get; set; }
        public int? Cat_id { get; set; }
        public int? Shop_id { get; set; }
    }
}