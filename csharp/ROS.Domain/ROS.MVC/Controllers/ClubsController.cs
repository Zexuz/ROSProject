using AutoMapper;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class ClubsController : Controller
    {

        // GET: Clubs
        public ActionResult Index()
        {
            var clubs = GetAllClubs();
            return View(clubs);
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Club club = GetAllClubs().Find(c => c.Id == id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }


        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        [HttpPost]       
        public ActionResult Create(CreateClubsViewModel createClubViewModel)
        {
            if (ModelState.IsValid)
            {
                AddressContact addressContact = CreateAddressContact(createClubViewModel);

                Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.Clubs.PocoClub, Club>());
                Club Clubs = Mapper.Map<Club>(createClubViewModel.Club);
                Clubs.AddressContactId = addressContact.Id;

                using (var context = new ClubContext())
                {
                    var service = new ClubService(context);
                    service.Create(Clubs);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
  
        private AddressContact CreateAddressContact(CreateClubsViewModel createClubViewModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.AddressContacts.AddressContact, AddressContact>());
            AddressContact addressContact = Mapper.Map<AddressContact>(createClubViewModel.AddressContact);
            using (var context = new AddressContactContext())
            {
                var service = new AddressContactService(context);
                service.Add(addressContact);
            }
            return addressContact;
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Club club = GetAllClubs().Find(c => c.Id == id);
            if (club == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AddressContactId = new SelectList(new AddressContactService(new AddressContactContext()).GetAll(), "Id", "NextOfKin",
            //    club.AddressContactId);
            //ViewBag.ContactPersonId = new SelectList(new ContactPersonService(new ContactPersonContext()).GetAll(), "Id","Email",
            //    club.ContactPersonsId);
            return View(club);
        }

        // POST: Clubs/Edit/5
        [HttpPost]
        public ActionResult Edit(Club club)
        {
            if (ModelState.IsValid)
            {
                new ClubService(new ClubContext()).Edit(club);
                return RedirectToAction("Index");
            }      
                return View();           
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Club club = GetAllClubs().Find(c => c.Id == id);
            if (club == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressContactId = new SelectList(new AddressContactService(new AddressContactContext()).GetAll(), "Id", "NextOfKin",
                club.AddressContactId);
            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            if (ModelState.IsValid)
            {
                //Club club = GetAllClubs().Find(c => c.Id == id);
                new ClubService(new ClubContext()).Delete(id);
                return RedirectToAction("Index");
            }

            return View();

        }
        private List<Club> GetAllClubs()
        {
            using (var context = new ClubContext())
            {
                var service = new ClubService(context);
                var clubs = service.GetAll();
                return clubs.ToList();
            }
        }
    }
}
