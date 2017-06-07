using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore1.Controllers
{
    public class CardPersonController : Controller
    {
        // GET: CardPerson
        public ActionResult Index(int? x)
        {
            int id = x.HasValue ? x.Value : 0;
            IEnumerable<Models.MyPerson> list = Code.Company.GetPersons();

            if (id < 0 || id >= list.Count())
            {
                id = 0;
            }

            Models.MyPerson person = list.ElementAt(id);

            return View(person);
        }
    }
}