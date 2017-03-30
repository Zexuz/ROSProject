using ROS.Domain.Models;
using ROS.Domain.PocoClasses.Clubs;
using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PocoClub = ROS.MVC.PocoClasses.Clubs.PocoClub;

namespace ROS.MVC.Controllers
{
    public class ClubController : Controller
    {
        public EntityDataModel db = new EntityDataModel();
        public ClubService clubService = new ClubService();
        // GET: Club
        public ActionResult Index()
        {
            
            return View(db.Clubs.ToList());
        }

        // GET: Club/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Club/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Club/Create
        [HttpPost]
        public ActionResult Create(PocoClub newClub)
        {
            try
            {
                clubService.Create(newClub);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Club/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Club/Edit/5
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

        // GET: Club/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Club/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                clubService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
