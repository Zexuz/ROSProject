
using System;

namespace ROS.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Password{ get; set; }

        public string Email { get; set; }

        public Name Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}