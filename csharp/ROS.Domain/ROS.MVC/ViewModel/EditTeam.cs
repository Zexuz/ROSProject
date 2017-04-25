using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROS.MVC.ViewModel
{
    public class EditTeam
    {
        public Team team { get; set; }
        public RaceEvent raceEvent {get; set;}
        public List<RegisteredUser> registeredUsers { get; set; }
        public List<User> users { get; set; }
    }
}