using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class ContactPersonController : Controller
    {
        // GET: ContactPerson
        public ActionResult Index()
        {
            var contactPersons = GetAllContactPersons();
            return View(contactPersons);
        }

        // GET: ContactPerson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ContactPerson contactPerson = GetAllContactPersons().Find(c => c.Id == id);
            if (contactPerson == null)
            {
                return HttpNotFound();
            }
            return View(contactPerson);
        }

        // GET: ContactPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactPerson/Create
        [HttpPost]
        public ActionResult Create(PocoClasses.ContactPerson contactPerson)
        {
            if (ModelState.IsValid)
            {
                //                new UserService(new UserContext()).Add(createUserViewModel.User);
                //                new AddressContactService().AddToDb(createUserViewModel.AddressContact);
                return RedirectToAction("Index");
            }

            return View(contactPerson);
        }

        // GET: ContactPerson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactPerson = GetAllContactPersons().Find(c => c.Id == id);
            if (contactPerson == null)
            {
                return HttpNotFound();
            }
            return View(contactPerson);
        }

        // POST: ContactPerson/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserId,Email,PhoneNumber")] ContactPerson contactperson)
        {
            if (ModelState.IsValid)
            {
                new ContactPersonService(new ContactPersonContext()).Edit(contactperson);
                return RedirectToAction("Index");
            }
            return View(contactperson);
        }

        // GET: ContactPerson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactPerson = GetAllContactPersons().Find(c => c.Id == id);
            if (contactPerson == null)
            {
                return HttpNotFound();
            }
            return View(contactPerson);
        }

        // POST: ContactPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactPerson contactPerson = GetAllContactPersons().Find(c => c.Id == id);
            new ContactPersonService(new ContactPersonContext()).Remove(contactPerson);
            return RedirectToAction("Index");
        }

        private List<ContactPerson> GetAllContactPersons()
        {
            using (var context = new ContactPersonContext())
            {
                var service = new ContactPersonService(context);
                var contactPersons = service.GetAll();
                return contactPersons.ToList();
            }
        }
    }
}
