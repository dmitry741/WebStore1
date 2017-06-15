using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebStore1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        public void Session_Start()
        {
            var cookie = Request.Cookies.Get("auth1");
            Session["auth"] = (cookie != null) ? Request.Cookies.Get("auth1").Value : string.Empty;
        }
    }
}
