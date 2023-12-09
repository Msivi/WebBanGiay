﻿using doAnGiay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;
using System.Runtime.Remoting.Contexts;

namespace doAnGiay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
         
        public ActionResult Index( int page=1)
        {
            CompanyDBContext db=new CompanyDBContext();
           List<Product> pro=db.products.ToList();

            //paing
            int NoOfRecordPerPage = 3;
            int NoOfPages=Convert.ToInt32(Math.Ceiling
                (Convert.ToDouble(pro.Count)/Convert.ToDouble(NoOfRecordPerPage)));
            int noOfRecordToSKip=(page-1)* NoOfRecordPerPage;
            ViewBag.page=page;
            ViewBag.noOfPage = NoOfPages;
            pro=pro.Skip(noOfRecordToSKip).Take(NoOfRecordPerPage).ToList();
            return View(pro );
        }
        public ActionResult chiTiet( int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product pro = db.products.Where(row=>row.ProductId==id ).FirstOrDefault();
            return View(pro);

        }
    }
}