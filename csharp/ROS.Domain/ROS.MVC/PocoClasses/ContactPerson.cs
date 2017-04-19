using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ROS.MVC.PocoClasses
{
    public class ContactPerson
    {
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
    }
}