﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookahMvcBookApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbBookahMvcBookAppEntities1 : DbContext
    {
        public dbBookahMvcBookAppEntities1()
            : base("name=dbBookahMvcBookAppEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tblCategory> tblCategories { get; set; }
        public DbSet<tblInvoice> tblInvoices { get; set; }
        public DbSet<tblOrder> tblOrders { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        public DbSet<tblBook> tblBooks { get; set; }
        public DbSet<getallbook> getallbooks { get; set; }
        public DbSet<viewallbook> viewallbooks { get; set; }
    }
}
