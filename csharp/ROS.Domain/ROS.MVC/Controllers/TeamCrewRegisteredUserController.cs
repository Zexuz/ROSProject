using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROS.MVC.Controllers
{
    public class TeamCrewRegisteredUserController : Controller
    {
        public ActionResult Create(int entryId, int teamId, List<RegisteredUser> regUsers)
        {
            var service = new UserService(new RosContext<User>());
            ViewBag.userId = new SelectList(service.GetAll(), "Id", "Email");
            return View();
        }

        [HttpPost]
        public ActionResult Create(int userId, int entryId, int teamId, List<RegisteredUser> regUsers)
        {
            if (userId != 0)
            {
                int regUserId;
                using (var context = new RegisteredUserContext())
                {
                    var service = new RegisteredUserService(context);
                    regUserId = service.GetIdByUserIdAndEntryId(userId, entryId);
                }
                using (var context = new TeamCrewRegisteredUserContext())
                {
                    var service = new TeamCrewRegisteredUserService(context);
                    if (!regUsers.Select(u => u.Id).Contains(regUserId))
                        service.Add(regUserId, teamId);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(userId);
        }
    }
}