using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class UserContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public UserContext()
        {
            Users = new EntityDataModel().Users;
        }
    }
}