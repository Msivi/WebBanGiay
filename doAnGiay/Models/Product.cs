using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace doAnGiay.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPuchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<bool> Active { get; set; }
        public int Size { get; set; }
        public string Gender { get; set; }
        public string ImageUrl{ get; set; }
        public Nullable<long> CategoryId { get; set; }
        public Nullable<long> BrandID { get; set; }
        
        virtual public Category Category { get; set; }

        virtual public Brands Brands { get; set; }
    }
}