using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doAnGiay.Filters
{
    public class AdminAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.IsInRole("Manager") ==false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}