using ROS.MVC.PocoClasses;
using ROS.MVC.PocoClasses.AddressContacts;
using ROS.MVC.PocoClasses.Clubs;
using ROS.MVC.PocoClasses.Regattas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROS.MVC.ViewModel
{
    public class CreateRegattaViewModel
    {
        public Regatta Regatta { get; set; }
        public AddressContact AddressContact { get; set; }
        public ContactPerson ContactPerson { get; set; }

    }
}