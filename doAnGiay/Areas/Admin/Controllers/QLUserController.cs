using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using doAnGiay.Areas.Admin.ViewModelAD;
using doAnGiay.Identity;
using doAnGiay.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using doAnGiay.Filters;

namespace doAnGiay.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class QLUserController : Controller
    {
        // GET: Admin/QLUser
        AppDBContext Appdb = new AppDBContext();
        public ActionResult Index()
        {
            List<AppUser> user = Appdb.Users.ToList();
            return View(user);
           
        }
        public ActionResult Edit(string id)
        {
            AppUser user = Appdb.Users.Where(row=>row.Id==id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(AppUser au)
        {
            AppUser ap = Appdb.Users.Where(row=>row.Id==au.Id).FirstOrDefault();
            ap.UserName = au.UserName;
            ap.PhoneNumber = au.PhoneNumber;
            ap.Email = au.Email;
            ap.Address = au.Address;
            ap.City = au.City;
            ap.Birthday= au.Birthday;
            Appdb.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(string id)
        {
            AppUser user = Appdb.Users.Where(row => row.Id == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(AppUser au)
        {
            AppUser ap = Appdb.Users.Where(row => row.Id == au.Id).FirstOrDefault();
            Appdb.Users.Remove(ap);
            Appdb.SaveChanges();
            return RedirectToAction("index");
        }
    }
}