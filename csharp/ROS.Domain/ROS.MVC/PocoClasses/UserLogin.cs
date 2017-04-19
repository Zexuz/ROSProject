using System.ComponentModel.DataAnnotations;

namespace ROS.MVC.PocoClasses
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}