using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ROS.Domain.Models;

namespace ROS.MVC.ViewModel
{
    public class CreateTeam
    {
        public IQueryable<Team> teams { get; set; }
        public string eventName { get; set; }
        public int? entryId { get; set; }
        public int regattaId { get; set; }
    }
}