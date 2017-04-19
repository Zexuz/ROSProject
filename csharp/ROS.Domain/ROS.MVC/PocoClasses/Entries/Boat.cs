using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ROS.MVC.PocoClasses.Entries
{
    public class Boat
    {
        [DisplayName("Sail number")]
        public string SailNumber { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Type")]
        public string Type { get; set; }

        [DisplayName("Handicap")]
        public double? Handicap { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}