using AutoMapper;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.ViewModel;
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
        public ActionResult Index(Entry entry)
        {
            CreateTeam teamModels = new CreateTeam();
            teamModels.entryId = entry.Id;
            teamModels.regattaId = entry.RegattaId;
            IQueryable<Team> teams;
            using (var context = new TeamContext())
            {
                var service = new TeamService(context);
                teams = service.GetAllByEntryId(entry.Id);
            }
            teamModels.teams = teams;
            return View(teamModels);
        }

        public ActionResult Create(int entryId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PocoClasses.Entries.Team newTeam, int entryId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.Entries.Team, Team>());
            Team team = Mapper.Map<Team>(newTeam);
            team.EntryId = entryId;

            if (ModelState.IsValid)
            {
                using (var context = new TeamContext())
                {
                    var service = new TeamService(context);
                    service.Add(team);
                }
                using (var context = new RaceEntryContext())
                {
                    var service = new RaceEntryService(context);
                    service.Add(team.Id, newTeam.EventId);
                }

                Entry entry;
                using (var context = new EntryContext())
                {
                    var service = new EntryService(context);
                    entry = service.GetById(entryId);
                }
                return RedirectToAction("Index", entry);
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
