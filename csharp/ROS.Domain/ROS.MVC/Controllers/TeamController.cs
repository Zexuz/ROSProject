using AutoMapper;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class TeamController : Controller
    {
        public ActionResult Index(int? entryId)
        {
            IQueryable<Team> teams;
            using (var context = new TeamContext())
            {
                var service = new TeamService(context);
                teams = service.GetAllByEntryId(Convert.ToInt32(entryId));
            }

            return View(teams);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PocoClasses.Entries.Team newTeam)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.Entries.Team, Team>());
            Team team = Mapper.Map<Team>(newTeam);

            if (ModelState.IsValid)
            {
                using (var context = new TeamContext())
                {
                    var service = new TeamService(context);
                    service.Add(team);
                }
                return RedirectToAction("Index");
            }
            return View(team);
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
