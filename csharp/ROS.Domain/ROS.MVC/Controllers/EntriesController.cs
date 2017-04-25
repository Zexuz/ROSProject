using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.PocoClasses.Entries;

namespace ROS.MVC.Controllers
{
    [System.Web.Mvc.Authorize]
    public class EntriesController : Controller
    {
        private EntityDataModel db = new EntityDataModel();
        private readonly EntryService _entryService = new EntryService();
        private readonly UserService _userService = new UserService(new UserContext());

        // GET: Entries
        public ActionResult Index()
        {
            var entries = _entryService.GetAll();
            return View(entries);
        }

        public ActionResult Join()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Join(JoinEntry joinEntry)
        {
            try
            {
                int entryId;
                using (var context = new EntryContext())
                {
                    var entryLogicService = new EntryService();
                    entryId = entryLogicService.GetByEntryNumber(int.Parse(joinEntry.EntryNumber)).Id;
                }
                using (var context = new RegisteredUserContext())
                {
                    var regUserService = new RegisteredUserService(context);
                    regUserService.JoinEntry(int.Parse(User.Identity.Name), entryId);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("EF broke... Ask robin");
            }
            return View();
        }


        // GET: Entries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = _entryService.GetById(id);
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
            ViewBag.SkipperId = new SelectList(_userService.GetAll(), "Id", "Email");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,BoatId,SkipperId,RegattaId,Number,RegistrationDate,HasPayed")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                _entryService.Add(entry);
                return RedirectToAction("Index");
            }

            ViewBag.BoatId = new SelectList(db.Boats, "Id", "SailNumber", entry.BoatId);
            ViewBag.RegattaId = new SelectList(db.Regattas, "Id", "Name", entry.RegattaId);
            ViewBag.SkipperId = new SelectList(_userService.GetAll(), "Id", "Email", entry.SkipperId);
            return View(entry);
        }

        // GET: Entries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = _entryService.GetById(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoatId = new SelectList(db.Boats, "Id", "SailNumber", entry.BoatId);
            ViewBag.RegattaId = new SelectList(db.Regattas, "Id", "Name", entry.RegattaId);
            ViewBag.SkipperId = new SelectList(_userService.GetAll(), "Id", "Email", entry.SkipperId);
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,BoatId,SkipperId,RegattaId,Number,RegistrationDate,HasPayed")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                _entryService.Edit(entry);
                return RedirectToAction("Index");
            }
            ViewBag.BoatId = new SelectList(db.Boats, "Id", "SailNumber", entry.BoatId);
            ViewBag.RegattaId = new SelectList(db.Regattas, "Id", "Name", entry.RegattaId);
            ViewBag.SkipperId = new SelectList(_userService.GetAll(), "Id", "Email", entry.SkipperId);
            return View(entry);
        }

        // GET: Entries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = _entryService.GetById(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // POST: Entries/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entry entry = _entryService.GetById(id);
            _entryService.Remove(entry);
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