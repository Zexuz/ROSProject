using System;
using System.ComponentModel;

namespace ROS.MVC.PocoClasses.Users
{
    public class User
    {

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Password Again")]
        public string PasswordAgain { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of birth")]
        public DateTime? DateOfBirth { get; set; }

    }
}
