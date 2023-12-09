using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace doAnGiay.Models
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext() : base("MyContext") { }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> products { get; set; }
    }
}