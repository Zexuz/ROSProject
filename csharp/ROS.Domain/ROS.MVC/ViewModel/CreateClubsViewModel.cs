using ROS.MVC.PocoClasses.AddressContacts;
using ROS.MVC.PocoClasses.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROS.MVC.ViewModel
{
    public class CreateClubsViewModel
    {
        public PocoClub club { get; set; }
        public AddressContact AddressContact { get; set; }
    }
}