using doAnGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doAnGiay.Filters;

namespace doAnGiay.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Category> cate = db.Category.ToList();
            return View(cate);
        }
    }
}