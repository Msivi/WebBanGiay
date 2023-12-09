using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  System.Collections;
using doAnGiay.Models;
using System.Web.Services.Description;
using doAnGiay.Filters;

namespace doAnGiay.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index( string search="", string SortColumn= "ProductId", string IconClass="fa-sort-asc",int page=1)
        {
            CompanyDBContext db = new CompanyDBContext();
            //List<Product> pro = db.products.ToList();
            //search
            List<Product> pro = db.products.Where(row=>row.ProductName.Contains(search)).ToList();
            //Sort
            ViewBag.SortColum = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn== "ProductId")
            {
                if (IconClass == "fa-sort-asc")
                {
                    pro = pro.OrderBy (row => row.ProductId).ToList();
                }
                else
                {
                    pro = pro.OrderByDescending(row => row.ProductId).ToList();
                }
                 
            }
           else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                {
                    pro = pro.OrderBy(row => row.ProductName).ToList();
                }
                else
                {
                    pro = pro.OrderByDescending(row => row.ProductName).ToList();
                }

            }
            else if(SortColumn== "Price")
            {
                
                
                if (IconClass == "fa-sort-asc")
                {
                    pro = pro.OrderBy(row => row.Price).ToList();
                }
                else
                {
                    pro=pro.OrderByDescending(row => row.Price).ToList();
                }
            }
            //paging 
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling
                (Convert.ToDouble(pro.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int noOfRecordToSKip = (page - 1) * NoOfRecordPerPage;
            ViewBag.page = page;
            ViewBag.noOfPage = NoOfPages;
            pro = pro.Skip(noOfRecordToSKip).Take(NoOfRecordPerPage).ToList();

            return View(pro);
        }
        [AuthorizationChiTiet]
        public ActionResult chiTietSP(int id)
        {
           
            CompanyDBContext db = new CompanyDBContext();
            Product pro = db.products.Where(row => row.ProductId == id).FirstOrDefault();
            return View(pro);

        }
        public ActionResult BrandNike()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> pro = db.products.ToList();
            return View(pro);
        }
        public ActionResult BrandAdidas()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> pro = db.products.ToList();
            return View(pro);
        }

        public ActionResult BrandMlb()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> pro = db.products.ToList();
            return View(pro);
        }
    }
}