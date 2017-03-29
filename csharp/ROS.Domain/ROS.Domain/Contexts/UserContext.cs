using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class UserContext:DbContext
    {
        public UserContext()
        {
            Users = new EntityDataModel().Users;
        }

        public virtual DbSet<User> Users { get; set; }
    }
}