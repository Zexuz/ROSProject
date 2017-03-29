using System.Collections.Generic;
using System.Linq;
using ROS.Domain.Contexts;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public class UserService
    {
        private readonly UserContext _userContext;

        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users;
        }
    }
}