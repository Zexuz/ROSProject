using AutoMapper;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class RegattaController : Controller
    {
        // GET: Regatta
        public ActionResult Index()
        {
            var regattas = GetAllRegattas();
            return View(regattas);
        }

        // GET: Regatta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Regatta regatta = GetAllRegattas().Find(r => r.Id == id);
            if (regatta == null)
            {
                return HttpNotFound();
            }
            return View(regatta);
        }

        // GET: Regatta/Create
        public ActionResult Create()
        {
            ViewBag.AddressContactId = new SelectList(new AddressContactService(new AddressContactContext()).GetAll(), "Id", "NextOfKin");
           // ViewBag.HostingClubId = new SelectList(new ClubService(new ClubContext()).GetAll(), "Id", "Name");
            //ViewBag.ContactPersonsId = new SelectList(new ContactPersonService(new ContactPersonContext()).GetAll(), "Id", "Email");
            return View();
        }

        // POST: Regatta/Create
        [HttpPost]
        public ActionResult Create(CreateRegattaViewModel createRegattaViewModel)
        {
            if (ModelState.IsValid)
            {
                AddressContact addressContact = CreateAddressContact(createRegattaViewModel);
                ContactPerson contactPerson = CreateContactPerson(createRegattaViewModel);

                Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.Regattas.Regatta, Regatta>());
                Regatta regatta = Mapper.Map<Regatta>(createRegattaViewModel.Regatta);
                regatta.AddressContactId = addressContact.Id;
                regatta.ContactPersonsId = contactPerson.Id;
                regatta.HostingClubId = FindClubId();
                

                using (var context = new RegattaContext())
                {
                    var service = new RegattaService(context);
                              service.Add(regatta);
                }               
                ViewBag.AddressContactId = new SelectList(new AddressContactContext().AddressContacts, "Id", "NextOfKin", regatta.AddressContactId);
                // ViewBag.AddressContactId = new SelectList(new AddressContactService(new AddressContactContext()).GetAll(),"Id","NextOfKin",regatta.AddressContactId);
                //  ViewBag.HostingClubId = new SelectList(new ClubService(new ClubContext()).GetAll(), "Id", "Name", regatta.HostingClubId);
                // ViewBag.ContactPersonsId = new SelectList(new ContactPersonService(new ContactPersonContext()).GetAll(), "Id", "Email", regatta.ContactPersonsId);

                return RedirectToAction("Index");
            }
            return View(createRegattaViewModel);
        }

        // GET: Regatta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regatta regatta = GetAllRegattas().Find(r => r.Id == id);
            if (regatta == null)
            {
                return HttpNotFound();
            }
            return View(regatta);
        }

        // POST: Regatta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
           [Bind(Include = "Id,AddressContactId,ContactPersonId,Name,StartDateTime,EndDateTime,Fee,Description")] Regatta regatta)
        {
            if (ModelState.IsValid)
            {
                new RegattaService(new RegattaContext()).Edit(regatta);
                return RedirectToAction("Index");
            }
            return View(regatta);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regatta regatta = GetAllRegattas().Find(r => r.Id == id);
            if (regatta == null)
            {
                return HttpNotFound();
            }
            return View(regatta);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regatta regatta = GetAllRegattas().Find(r => r.Id == id);
            new RegattaService(new RegattaContext()).Remove(regatta);
            return RedirectToAction("Index");
        }

        private List<Regatta> GetAllRegattas()
        {
            using (var context = new RegattaContext())
            {
                var service = new RegattaService(context);
                var regattas = service.GetAll();
                return regattas.ToList();
            }
        }

        private AddressContact CreateAddressContact(CreateRegattaViewModel createRegattaViewModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.AddressContacts.AddressContact, AddressContact>());
            AddressContact addressContact = Mapper.Map<AddressContact>(createRegattaViewModel.AddressContact);
            using (var context = new AddressContactContext())
            {
                var service = new AddressContactService(context);
                service.Add(addressContact);
            }
            return addressContact;
        }

        private ContactPerson CreateContactPerson(CreateRegattaViewModel createRegattaViewModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.ContactPerson, ContactPerson>());
            ContactPerson contactPerson = Mapper.Map<ContactPerson>(createRegattaViewModel.ContactPerson);
            using (var context = new ContactPersonContext())
            {
                var service = new ContactPersonService(context);
                service.Add(contactPerson);
            }
            return contactPerson;
        }

        private int FindClubId()
        {
            int userId = int.Parse(User.Identity.Name);
            using (var context = new ClubAdminContext())
            {
                var service = new ClubAdminService(context);
                int clubId = service.GetAll().SingleOrDefault(c => c.UserId == userId).ClubId;
                return clubId;
            }
            
        }
    }
}
