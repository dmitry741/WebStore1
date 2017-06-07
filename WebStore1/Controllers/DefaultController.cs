using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore1.Controllers
{
    public class DefaultController : Controller
    {        
        IEnumerable<Models.MyPerson> GetPersons()
        {
            var persons = new List<Models.MyPerson>
            {
                new Models.MyPerson
                {
                    FirstName = "Dmitry",
                    LastName = "Pavlov",
                    age = 43,
                    position = "Software developer"
                },
                new Models.MyPerson
                {
                    FirstName = "Petr",
                    LastName = "Ivanov",
                    age = 30,
                    position = "Web designer"
                },
                new Models.MyPerson
                {
                    FirstName = "Lubov",
                    LastName = "Petrova",
                    age = 31,
                    position = "Front-end developer"
                }
            };

            return persons;
        }

        public ActionResult Index()
        {
            return View(GetPersons());
        }
    }
}