﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TikiContext : DbContext
    {
        public TikiContext()
            : base("name=TikiContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTHOR> AUTHORs { get; set; }
        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<COMPANY> COMPANies { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<EVALUATE> EVALUATEs { get; set; }
        public virtual DbSet<ORDER_DETAIL> ORDER_DETAIL { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PUBLISHER> PUBLISHERs { get; set; }
        public virtual DbSet<SHOP> SHOPs { get; set; }
    }
}
