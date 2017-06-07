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
        public ActionResult Index()
        {
            int id = 0;
            IEnumerable<Models.MyPerson> list = Code.Company.GetPersons();
            Models.MyPerson person = list.ElementAt(id);

            return View(person);
        }
    }
}