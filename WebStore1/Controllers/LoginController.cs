﻿using System;
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
        private static List<User> users = new List<User>
        {
            new User { Login = "admin", Password = "12345" }
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
                return View(auth);

            if (!CheckAuthParams(auth))
            {
                auth.ErrorMessage = "Authentification error";
                return View(auth);
            }

            FormsAuthentication.SetAuthCookie(auth.Login, true);
            FormsAuthentication.SignOut();

            return Redirect(FormsAuthentication.DefaultUrl);
        }

        private bool CheckAuthParams(AuthentificationParams auth)
        {
            var user = users.FirstOrDefault(x => x.Login.Trim().ToLower() == auth.Login.Trim().ToLower());

            if (user != default(User))
                return auth.Password.Trim().ToLower() == user.Password.Trim().ToLower();

            return false;
        }

    }
}