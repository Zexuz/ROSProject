using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Models
{
    public class Race
    {
        public int Id { get; set; }
        public int MinHandicap { get; set; }
        public int MaxHandicap { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }

    }
}
