using ROS.Domain.Models;
using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class AddressContactController : Controller
    {
        // GET: AddressContact
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddressContact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddressContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressContact/Create
        [HttpPost]
        public ActionResult Create(AddressContact addressContact)
        {
            try
            {
                // TODO: Add insert logic here
                //_service.Add(addressContact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressContact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddressContact/Edit/5
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

        // GET: AddressContact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddressContact/Delete/5
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
