using ROS.Domain.Services;
using ROS.Domain.PocoClasses.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class BoatController : Controller
    {
        private BoatService _boatService = new BoatService();

        public ActionResult Index()
        {
            return View();
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

        // GET: Boat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Boat/Edit/5
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

        // GET: Boat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Boat/Delete/5
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
    }
}
