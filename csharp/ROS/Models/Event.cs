using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Models
{
    class Event
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }
        public int Fee { get; set; }
        public string Description { get; set; }
    }
}
