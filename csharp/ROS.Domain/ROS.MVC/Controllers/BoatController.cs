using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using ROS.Domain.Models;
using ROS.Domain.Contexts;
using ROS.MVC.ViewModel;
using AutoMapper;

namespace ROS.MVC.Controllers
{
    public class BoatController : Controller
    {

        public ActionResult Index()
        {
            var users = GetAllBoats();
            return View(users);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Boat boat = GetAllBoats().Find(b => b.Id == id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        public ActionResult Create()
        {
            return View();
        }

            
        [HttpPost]
        public ActionResult Create(PocoClasses.Entries.Boat newBoat)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.Entries.Boat, Boat>());
            Boat boat = Mapper.Map<Boat>(newBoat);

            if (ModelState.IsValid)
            {
                
                using (var context = new BoatContext())
                {
                    var service = new BoatService(context);
                    service.Add(boat);
                }
                return RedirectToAction("Index");
            }

            return View(newBoat);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = GetAllBoats().Find(b => b.Id == id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boat boat = GetAllBoats().Find(b => b.Id == id);
            using (var context = new BoatContext())
            {
                var service = new BoatService(context);
                service.Remove(boat);
            }
            return RedirectToAction("Index");
        }

        private List<Boat> GetAllBoats()
        {
            using (var context = new BoatContext())
            {
                var service = new BoatService(context);
                var boats = service.GetAll();
                return boats.ToList();
            }
        }
    }
}
