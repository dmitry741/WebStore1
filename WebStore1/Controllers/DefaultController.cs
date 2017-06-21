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
            WebStore.DAL.DbContext.WebStoreContext wc = new WebStore.DAL.DbContext.WebStoreContext();
            Domain.Entities.MyPerson model = wc.Persons.FirstOrDefault(x => x.id == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveAdd(Domain.Entities.MyPerson model)
        {
            if (ModelState.IsValid)
            {
                WebStore.DAL.DbContext.WebStoreContext wc = new WebStore.DAL.DbContext.WebStoreContext();
                wc.Persons.Add(model);
                int count = wc.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("AddPerson", model);
        }

        [HttpPost]
        public ActionResult SaveEdit(Domain.Entities.MyPerson model)
        {
            if (ModelState.IsValid)
            {
                WebStore.DAL.DbContext.WebStoreContext wc = new WebStore.DAL.DbContext.WebStoreContext();
                Domain.Entities.MyPerson p = wc.Persons.FirstOrDefault(x => x.id == model.id);

                if (p != default(Domain.Entities.MyPerson))
                {
                    wc.Persons.Remove(p);
                    wc.Persons.Add(model);
                    int count = wc.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View("EditPerson", model);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                WebStore.DAL.DbContext.WebStoreContext wc = new WebStore.DAL.DbContext.WebStoreContext();
                Domain.Entities.MyPerson p = wc.Persons.FirstOrDefault(x => x.id == id);

                if (p != default(Domain.Entities.MyPerson))
                {
                    wc.Persons.Remove(p);
                    int count = wc.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Index(int? x)
        {
            WebStore.DAL.DbContext.WebStoreContext wc = new WebStore.DAL.DbContext.WebStoreContext();
            var myListPersons = wc.Persons.ToList();
            var list = myListPersons;

            if (x.HasValue)
            {
                if (x.Value == 1)
                {
                    list = myListPersons.OrderBy(p => p.LastName).ToList();
                }
                else if (x.Value == 2)
                {
                    list = myListPersons.OrderByDescending(p => p.LastName).ToList();
                }
            }

            return View(list);                                                            
        }

        [AllowAnonymous]
        public ActionResult CardPerson(int? x)
        {
            WebStore.DAL.DbContext.WebStoreContext wc = new WebStore.DAL.DbContext.WebStoreContext();
            var list = wc.Persons.ToList();

            int id = x.HasValue ? x.Value : 0;
            Domain.Entities.MyPerson person = list.FirstOrDefault(p => p.id == id);

            return View(person);
        }
    }
}