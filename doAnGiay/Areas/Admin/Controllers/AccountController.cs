using doAnGiay.Areas.Admin.ViewModelAD;
using doAnGiay.Identity;
using doAnGiay.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using doAnGiay.Filters;
using doAnGiay.Models;

namespace doAnGiay.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class AccountController : Controller
    {
        // GET: Admin/Account
        AppDBContext Appdb=new AppDBContext();
        public ActionResult RegiterAD()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegiterAD(registerVMAD rvm)
        {
            if (ModelState.IsValid)
            {
                var appDBContext = new AppDBContext();
                var userStore = new AppUserStore(appDBContext);
                var userManager = new AppUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.UserName,
                    PasswordHash = passwordHash,
                    City = rvm.City,
                    Birthday = rvm.DateOfBirth,
                    Address = rvm.Address,
                    PhoneNumber = rvm.Mobile

                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    //var authenManager = HttpContext.GetOwinContext().Authentication;
                    //var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    //authenManager.SignIn(new AuthenticationProperties(), userIdentity);

                }
                return RedirectToAction("Index", "Home","admin");
            }
            else
            {
                ModelState.AddModelError("New Error", "Ivalid Data");
                return View();
            }
        }
        //public ActionResult showUser()
        //{
        //    List<AppUser> user = Appdb.Users.ToList();
        //    return View(user);
        //}
    }
}