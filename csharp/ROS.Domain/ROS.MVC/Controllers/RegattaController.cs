using ROS.Domain.Models;
using ROS.Domain.PocoClasses.Regattas;
using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class RegattaController : Controller
    {
        public EntityDataModel db = new EntityDataModel();
        public RegattaService _regattaService = new RegattaService();

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
        public ActionResult Create([Bind(Include = "ContactPerson,HostingClubId,AddressContact,Name,StartDateTime,EndDateTime,Fee,Description,ContactPersonEmail,ContactPersonPhoneNumber,PhoneNumber,Country,BoxNumber,StreetAddress,City,ZipCode")] PocoRegatta newRegatta)
        {
            try
            {
                _regattaService.Add(newRegatta);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
