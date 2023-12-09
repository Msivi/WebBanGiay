using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace doAnGiay.Models
{
    public class Brands
    {
        [Key]
        public long BrandID { get; set; }
        public string BrandName { get; set; }
    }
}