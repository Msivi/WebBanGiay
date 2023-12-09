using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using doAnGiay.Models;
using System.Web.Services.Description;
using System.IO;
using doAnGiay.Filters;
using System.Runtime.CompilerServices;
using System.Net;
using Newtonsoft.Json;

namespace doAnGiay.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string search = "", string SortColumn = "ProductId", string IconClass = "fa-sort-asc", int page = 1)
        {
            CompanyDBContext db = new CompanyDBContext();
            //List<Product> pro = db.products.ToList();
            //search
            List<Product> pro = db.products.Where(row => row.ProductName.Contains(search)).ToList();
            //Sort
            ViewBag.SortColum = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ProductId")
            {
                if (IconClass == "fa-sort-asc")
                {
                    pro = pro.OrderBy(row => row.ProductId).ToList();
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
            else if (SortColumn == "Price")
            {


                if (IconClass == "fa-sort-asc")
                {
                    pro = pro.OrderBy(row => row.Price).ToList();
                }
                else
                {
                    pro = pro.OrderByDescending(row => row.Price).ToList();
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
        public ActionResult chiTietSP(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product pro = db.products.Where(row => row.ProductId == id).FirstOrDefault();
            return View(pro);

        }
        public ActionResult Create( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pro, HttpPostedFileBase imgFile)
        {
            CompanyDBContext db = new CompanyDBContext();
            string path = Path.Combine(Server.MapPath("/imgs/"), Path.GetFileName(imgFile.FileName));
            imgFile.SaveAs(path);
            pro.ImageUrl = "/imgs/" +imgFile.FileName;
            db.products.Add(pro);
             db.SaveChanges();
            return RedirectToAction("Index");
    
        }

        public ActionResult Edit(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product pro= db.products.Where(row => row.ProductId == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product pro, HttpPostedFileBase imgFile)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product product = db.products.Where(row => row.ProductId == pro.ProductId).FirstOrDefault();
            //update
            product.ProductName = pro.ProductName;
            product.Price=pro.Price;
            product.DateOfPuchase = pro.DateOfPuchase;
            product.AvailabilityStatus = pro.AvailabilityStatus;
            product.Active = pro.Active;
            product.Size=pro.Size;
            product.BrandID = pro.BrandID;
            product.CategoryId=pro.CategoryId;
            product.Gender = pro.Gender;
            string path = Path.Combine(Server.MapPath("/imgs/"), Path.GetFileName(imgFile.FileName));
            imgFile.SaveAs(path);
            product.ImageUrl = "/imgs/" + imgFile.FileName;
            //db.products.Add(pro);
            //product.ImageUrl =pro.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("index","product","admin");
        }
        public ActionResult Delete(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product pro = db.products.Where(row => row.ProductId == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(int id,Product x)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product pro = db.products.Where(row => row.ProductId == id).FirstOrDefault();
            db.products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult adBrandNike()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> pro = db.products.ToList();
            return View(pro);
        }
        public ActionResult adBrandAdidas()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> pro = db.products.ToList();
            return View(pro);
        }

        public ActionResult adBrandMlb()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> pro = db.products.ToList();
            return View(pro);
        }

        public ActionResult getProduct()
        {
            return View();
        }

        //get product
        
    }
}