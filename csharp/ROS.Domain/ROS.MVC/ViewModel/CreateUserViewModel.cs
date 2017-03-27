using ROS.Domain.Models;

namespace ROS.MVC.ViewModel
{
    public class CreateUserViewModel
    {
        public User User { get; set; }
        public AddressContact AddressContact { get; set; }
    }
}