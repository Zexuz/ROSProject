using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Regatta_AddressContact_ContactPerson_Create = ROS.MVC.PocoClasses.Regattas.Regatta_AddressContact_ContactPerson_Create;

namespace ROS.MVC.Controllers
{
    public class RegattaController : Controller
    {
        AddressContactService _addressContactService = new AddressContactService();
        // GET: Regatta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Regatta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Regatta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regatta/Create
        [HttpPost]
        public ActionResult Create(Regatta_AddressContact_ContactPerson_Create collection)
        {
            try
            {
                // TODO: Add insert logic here
//                _addressContactService.Add(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Regatta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Regatta/Edit/5
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

        // GET: Regatta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Regatta/Delete/5
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
