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
        public static List<User> users = new List<User>
        {
            new User { Login = "admin", Password = "12345" },
            new User { Login = "user1", Password = "12345" }
        };

        public LoginController()
        {
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new AuthentificationParams { });
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

            if (cookie == null)
            {
                cookie = new HttpCookie("auth1");

                // Set value of cookie to current user name.
                cookie.Value = auth.Login;

                // Set cookie to expire in 10 minutes.
                cookie.Expires = DateTime.Now.AddMinutes(120d);

                // Insert the cookie in the current HttpResponse.
                Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = auth.Login;
            }

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
                    cookie.Value = string.Empty;
                }
            }

            return Redirect(FormsAuthentication.DefaultUrl);
        }

        private bool CheckAuthParams(AuthentificationParams auth)
        {
            var user = users.FirstOrDefault(x => x.Login.Trim().ToLower() == auth.Login.Trim().ToLower());

            if (user != default(User))
            {
                return auth.Password.Trim() == user.Password.Trim();
            }

            return false;
        }

        public string AuthUser
        {
            get
            {
                var cookie = Request.Cookies.Get("auth1");

                return (cookie != null) ? Request.Cookies.Get("auth1").Value : string.Empty;
            }
        }
    }
}