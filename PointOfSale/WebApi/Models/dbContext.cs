using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    public class dbContext : DbContext
    {
        public dbContext() : base("conn")
        {

        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
    }
}