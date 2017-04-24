using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ROS.MVC.PocoClasses.Entries
{
    public class Team
    {
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}