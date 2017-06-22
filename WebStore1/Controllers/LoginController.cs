using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebStore1.Models;

namespace WebStore1.Controllers
{
    public class LoginController : Controller
    {
        public List<Domain.Entities.User> users
        {
            get
            {
                WebStore.DAL.DbContext.WebStoreContext wc = new WebStore.DAL.DbContext.WebStoreContext();
                return wc.Users.ToList();
            }
        }

        public LoginController()
        {
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new AuthentificationParams());
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_(AuthentificationParams auth)
        {
            if (!ModelState.IsValid)
            {
                auth.ErrorMessage = "Authentification error. Check for input parameters";
                return View(auth);
            }                

            if (!CheckAuthParams(auth))
            {
                auth.ErrorMessage = "Authentification error";
                return View(auth);
            }

            FormsAuthentication.SetAuthCookie(auth.Login, true);
            HttpCookie cookie = Request.Cookies.Get("auth1");

            if (cookie != null)
            {
                Request.Cookies.Remove("auth1");
            }
 
            cookie = new HttpCookie("auth1");

            // Set value of cookie to current user name.
            cookie.Value = auth.Login;

            // Set cookie to expire in 10 minutes.
            cookie.Expires = DateTime.Now.AddMinutes(120d);

            // Insert the cookie in the current HttpResponse.
            Response.Cookies.Add(cookie);

            Session["auth"] = auth.Login;

            return Redirect(FormsAuthentication.DefaultUrl);
        }

        public ActionResult SignOut(AuthentificationParams auth)
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                HttpCookie cookie = Request.Cookies.Get("auth1");

                if (cookie != null)
                {
                    Request.Cookies.Remove("auth1");
                }
            }

            return Redirect(FormsAuthentication.DefaultUrl);
        }

        private bool CheckAuthParams(AuthentificationParams auth)
        {
            var user = users.FirstOrDefault(x => x.Login.Trim().ToLower() == auth.Login.Trim().ToLower());

            return (user != default(Domain.Entities.User)) ? auth.Password.Trim() == user.Password.Trim() : false;
        }
    }
}