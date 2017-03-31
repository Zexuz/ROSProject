using ROS.MVC.PocoClasses.AddressContacts;
using ROS.MVC.PocoClasses.Users;

namespace ROS.MVC.ViewModel
{
    public class CreateUserViewModel
    {
        public User User { get; set; }
        public AddressContact AddressContact { get; set; }
    }
}