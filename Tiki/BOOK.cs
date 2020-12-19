//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tiki
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            this.EVALUATEs = new HashSet<EVALUATE>();
            this.ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }
    
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string book_img { get; set; }
        public Nullable<int> book_price { get; set; }
        public int book_sale { get; set; }
        public DateTime public_date { get; set; }
        public Nullable<double> width { get; set; }
        public Nullable<double> height { get; set; }
        public Nullable<int> page_number { get; set; }
        public string cover_type { get; set; }
        public string article { get; set; }
        public string translator { get; set; }
        public Nullable<int> aut_id { get; set; }
        public Nullable<int> com_id { get; set; }
        public Nullable<int> pub_id { get; set; }
        public Nullable<int> cat_id { get; set; }
        public Nullable<int> shop_id { get; set; }
    
        public virtual AUTHOR AUTHOR { get; set; }
        public virtual CATEGORY CATEGORY { get; set; }
        public virtual COMPANY COMPANY { get; set; }
        public virtual PUBLISHER PUBLISHER { get; set; }
        public virtual SHOP SHOP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUATE> EVALUATEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}
