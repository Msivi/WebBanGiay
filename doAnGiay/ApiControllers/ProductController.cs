using doAnGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace doAnGiay.ApiControllers
{
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> pro = db.products.ToList();
            return pro;
        }
        

    }   
}
