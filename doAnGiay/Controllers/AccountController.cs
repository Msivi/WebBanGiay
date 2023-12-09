using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using doAnGiay.Models;
using doAnGiay.ViewModel;
using doAnGiay.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace doAnGiay.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Regiter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regiter(RegiterVM rvm)
        {
            if(ModelState.IsValid)
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
                if(identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Ivalid Data");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(loginVM lvm)
        {
            var appDBContext = new AppDBContext();
            var userStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lvm.UserName, lvm.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext
                    ().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and password");

                return View();
            }
              
        }

        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("index", "Home");
        }
    }
}