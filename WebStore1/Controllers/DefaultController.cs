using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore1.Controllers
{
    public class DefaultController : Controller
    {
        static IEnumerable<Models.MyPerson> s_persons;

        public static IEnumerable<Models.MyPerson> persons
        {
            get
            {
                if (s_persons == null)
                    s_persons = Code.Company.GetPersons();

                return s_persons;
            }
        }

        public ActionResult Index(int? x)
        {
            IEnumerable<Models.MyPerson> emploees = persons;
            var list = emploees;

            if (x.HasValue)
            {               
                if (x.Value == 1)
                {
                    list = emploees.OrderBy(p => p.LastName);
                }
                else if (x.Value == 2)
                {
                    list = emploees.OrderByDescending(p => p.LastName);
                }
            }

            return View(list);
        }
    }
}