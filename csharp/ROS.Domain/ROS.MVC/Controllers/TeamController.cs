using AutoMapper;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
                    var service = new EntryService(new RosContext<Entry>());
                    entry = service.GetById(entryId);
                }
                return RedirectToAction("Index", entry);
            }
            return View(team);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditTeam editTeam = CreateEditTeam(id);

            return View(editTeam);
    
            
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

        public EditTeam CreateEditTeam(int? id)
        {
            Team team;
            using (var context = new TeamContext())
            {
                var service = new TeamService(context);
                team = service.GetAll().SingleOrDefault(t => t.Id == id);
            }
            EditTeam editTeamViewModel = new EditTeam();
            editTeamViewModel.team = team;
            RaceEntry raceEntry;
            using (var context = new RaceEntryContext())
            {
                var service = new RaceEntryService(context);
                raceEntry = service.GetByTeamId(team.Id);
            }
            using (var context = new RaceEventContext())
            {
                editTeamViewModel.raceEvent = context.RaceEvents.SingleOrDefault(r => r.Id == raceEntry.RaceId);
            }
            editTeamViewModel.registeredUsers = new List<RegisteredUser>();
            editTeamViewModel.users = new List<User>();
            IEnumerable<int> registeredUserIds;
            using (var context = new TeamCrewRegisteredUserContext())
            {
                var service = new TeamCrewRegisteredUserService(context);
                registeredUserIds = service.GetAllregisteredUserIdsByTeamId(team.Id);
            }
            using (var context = new RegisteredUserContext())
            {
                var RUservice = new RegisteredUserService(context);
                var userService = new UserService(new UserContext());
                foreach (int rUserId in registeredUserIds)
                {
                    int userId = RUservice.GetUserIdById(rUserId);
                    RegisteredUser registeredUser = RUservice.GetById(rUserId);
                    User user = userService.GetAll().SingleOrDefault(u => u.Id == userId);
                    editTeamViewModel.registeredUsers.Add(registeredUser);
                    editTeamViewModel.users.Add(user);
                }
            }
            return editTeamViewModel;
        }
    }
}
