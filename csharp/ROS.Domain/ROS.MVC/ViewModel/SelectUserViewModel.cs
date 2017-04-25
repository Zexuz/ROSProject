using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROS.MVC.ViewModel
{
    public class SelectUserViewModel
    {
        public User user { get; set; }
        public RegisteredUser registeredUser { get; set; }

    }
}