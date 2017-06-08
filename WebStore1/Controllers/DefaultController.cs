using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore1.Controllers
{
    public class DefaultController : Controller
    {        

        public ActionResult Index(int? x)
        {
            IEnumerable<Models.MyPerson> persons = Code.Company.GetPersons();
            var list = persons;

            if (x.HasValue)
            {               
                if (x.Value == 1)
                {
                    list = persons.OrderBy(p => p.LastName);
                }
                else if (x.Value == 2)
                {
                    list = persons.OrderByDescending(p => p.LastName);
                }
            }

            return View(list);
        }
    }
}