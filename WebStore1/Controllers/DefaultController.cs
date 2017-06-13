using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore1.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        
        public ActionResult AddPerson()
        {
            return View();
        }

        public ActionResult EditPerson(int id)
        {
            Models.MyPerson model = Code.Company.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveAdd(Models.MyPerson model)
        {
            if (ModelState.IsValid)
            {
                Code.Company.Add(model);
                return RedirectToAction("Index");
            }

            return View("AddPerson", model);
        }

        [HttpPost]
        public ActionResult SaveEdit(Models.MyPerson model)
        {
            if (ModelState.IsValid)
            {
                Code.Company.Edit(model);
                return RedirectToAction("Index");
            }

            return View("EditPerson", model);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Code.Company.Delete(id.Value);
            }

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult CardPerson(int? x)
        {
            int id = x.HasValue ? x.Value : 0;
            IEnumerable<Models.MyPerson> list = Code.Company.Persons;
            Models.MyPerson person = list.FirstOrDefault(p => p.id == id);

            return View(person);
        }
    }
}