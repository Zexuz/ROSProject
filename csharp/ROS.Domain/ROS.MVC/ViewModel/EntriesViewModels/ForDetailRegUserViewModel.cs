using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ROS.Domain.Models;

namespace ROS.MVC.ViewModel.EntriesViewModels
{
    public class ForDetailRegUserViewModel
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}