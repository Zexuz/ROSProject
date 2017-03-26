﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ROS.Domain.Models;

namespace ROS.MVC.Controllers
{
    public class EntriesController : Controller
    {
        private EntityDataModel db = new EntityDataModel();

        // GET: Entries
        public ActionResult Index()
        {
            var entries = db.Entries.Include(e => e.Boat).Include(e => e.Regatta).Include(e => e.User);
            return View(entries.ToList());
        }

        // GET: Entries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // GET: Entries/Create
        public ActionResult Create()
        {
            ViewBag.BoatId = new SelectList(db.Boats, "Id", "SailNumber");
            ViewBag.RegattaId = new SelectList(db.Regattas, "Id", "Name");
            ViewBag.SkipperId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BoatId,SkipperId,RegattaId,Number,RegistrationDate,HasPayed")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entries.Add(entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoatId = new SelectList(db.Boats, "Id", "SailNumber", entry.BoatId);
            ViewBag.RegattaId = new SelectList(db.Regattas, "Id", "Name", entry.RegattaId);
            ViewBag.SkipperId = new SelectList(db.Users, "Id", "Email", entry.SkipperId);
            return View(entry);
        }

        // GET: Entries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoatId = new SelectList(db.Boats, "Id", "SailNumber", entry.BoatId);
            ViewBag.RegattaId = new SelectList(db.Regattas, "Id", "Name", entry.RegattaId);
            ViewBag.SkipperId = new SelectList(db.Users, "Id", "Email", entry.SkipperId);
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BoatId,SkipperId,RegattaId,Number,RegistrationDate,HasPayed")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoatId = new SelectList(db.Boats, "Id", "SailNumber", entry.BoatId);
            ViewBag.RegattaId = new SelectList(db.Regattas, "Id", "Name", entry.RegattaId);
            ViewBag.SkipperId = new SelectList(db.Users, "Id", "Email", entry.SkipperId);
            return View(entry);
        }

        // GET: Entries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entry entry = db.Entries.Find(id);
            db.Entries.Remove(entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}