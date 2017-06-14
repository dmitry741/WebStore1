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
           
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        public ActionResult SignOut(AuthentificationParams auth)
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }

            return Redirect(FormsAuthentication.DefaultUrl);
        }

        private bool CheckAuthParams(AuthentificationParams auth)
        {
            var user = users.FirstOrDefault(x => x.Login.Trim().ToLower() == auth.Login.Trim().ToLower());

            if (user != default(User))
            {
                Session["auth"] = user;
                return auth.Password.Trim() == user.Password.Trim();
            }

            return false;
        }
    }
}