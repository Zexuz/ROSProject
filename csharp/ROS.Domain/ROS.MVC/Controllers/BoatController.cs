using ROS.Domain.Services;
using ROS.Domain.PocoClasses.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using ROS.Domain.Models;

namespace ROS.MVC.Controllers
{
    public class BoatController : Controller
    {
        public EntityDataModel db = new EntityDataModel();
        public BoatService _boatService = new BoatService();

        public ActionResult Index()
        {
            return View(db.Boats.ToList());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "SailNumber,Name,Type,Handicap,Description")] PocoBoat newBoat)
        {
            try
            {
                _boatService.Add(newBoat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = db.Boats.Find(id);
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
            _boatService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
