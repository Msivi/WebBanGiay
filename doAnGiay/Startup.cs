using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using doAnGiay.Identity;

[assembly: OwinStartup(typeof(doAnGiay.Startup))]

namespace doAnGiay
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            
            });
            this.CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            var RoleManager = new RoleManager<IdentityRole>(new
                RoleStore<IdentityRole>(new AppDBContext()));
            var appDBContext = new AppDBContext();
            var appUserStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManager(appUserStore);

            //if (!RoleManager.RoleExists("Admin1"))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Admin1";
            //    RoleManager.Create(role);
            //}
            //if (userManager.FindByName("admin1") == null)
            //{
            //    var user = new AppUser();
            //    user.UserName = "admin1";
            //    user.Email = "admin@gmail.com";
            //    string userPwd = "levi";
            //    var chkUser = userManager.Create(user, userPwd);
            //    if (chkUser.Succeeded)
            //    {
            //        userManager.AddToRole(user.Id, "Admin1");
            //    }
            //}

            if (!RoleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                RoleManager.Create(role);
            }
            if (userManager.FindByName("manager") == null)
            {
                var user = new AppUser();
                user.UserName = "manager";
                user.Email = "levi@gmail.com";
                string userPwd = "leviMG";
                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }
           
           

            if (!RoleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                RoleManager.Create(role);
            }
        }
    }
}
