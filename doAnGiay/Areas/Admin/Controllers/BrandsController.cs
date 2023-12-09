﻿using doAnGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doAnGiay.Filters;

namespace doAnGiay.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Brands> bran = db.Brands.ToList();
            return View(bran);
        }
    }
}