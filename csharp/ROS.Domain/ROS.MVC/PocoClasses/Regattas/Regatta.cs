using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ROS.MVC.PocoClasses.Regattas
{
    public class Regatta
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Start DateTime")]
        public DateTime StartDateTime { get; set; }

        [DisplayName("End DateTime")]
        public DateTime EndDateTime { get; set; }

        [DisplayName("Fee")]
        public int Fee { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}