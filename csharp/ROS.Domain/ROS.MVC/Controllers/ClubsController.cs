using AutoMapper;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Details(int id)
        {
            return View();
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
                Club Clubs = Mapper.Map<Club>(createClubViewModel.club);
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clubs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clubs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
