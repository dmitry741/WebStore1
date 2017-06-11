using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore1.Controllers
{
    public class DefaultController : Controller
    {
        
        public ActionResult AddEditPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAdd(Models.MyPerson model)
        {
            if (ModelState.IsValid)
            {
                Code.Company.Add(model);
                return RedirectToAction("Index");
            }

            return View("AddEditPerson", model);
        }

        public ActionResult Index(int? x)
        {
            IEnumerable<Models.MyPerson> emploees = Code.Company.Persons;
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

        public ActionResult CardPerson(int? x)
        {
            int id = x.HasValue ? x.Value : 0;
            IEnumerable<Models.MyPerson> list = Code.Company.Persons;

            if (id < 0 || id >= list.Count())
            {
                id = 0;
            }

            Models.MyPerson person = list.FirstOrDefault(p => p.id == id);

            return View(person);
        }
    }
}