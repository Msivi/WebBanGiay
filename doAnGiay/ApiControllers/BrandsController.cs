using doAnGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
 

namespace doAnGiay.ApiControllers
{
    public class BrandsController : ApiController
    {
        public List<Brands> Get ()
        {
            CompanyDBContext db = new CompanyDBContext ();
            List<Brands> brands = db.Brands.ToList();
            return brands;
        }
    }
}
