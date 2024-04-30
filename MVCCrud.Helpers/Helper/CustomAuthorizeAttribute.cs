using System;  
using System.Collections.Generic;
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
using System.Web.Routing;  
  
namespace MVCCrud.Helpers.Helper
{  
    public class CustomAuthorizeAttribute : AuthorizeAttribute  
    {  
        protected override bool AuthorizeCore(HttpContextBase httpContext)  
        {
            return HttpContext.Current.Session["UserID"] != null && HttpContext.Current.Session["UserName"] != null;
        }  
  
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)  
        {  
            filterContext.Result = new RedirectToRouteResult(  
               new RouteValueDictionary  
               {  
                    { "controller", "Login" },  
                    { "action", "SignIn" }  
               });  
        }  
    }  
}  