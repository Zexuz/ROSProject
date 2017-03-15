using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Models
{
    public class Result
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan CalculatedTime { get; set; }
        public int Distance { get; set; }
        public int CalculatedDistance { get; set; }

    }
}
