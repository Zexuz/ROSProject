using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Models
{
    class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public string HomePage { get; set; }
        public string Description { get; set; }
    }
}
