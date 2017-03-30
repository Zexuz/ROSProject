using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public sealed class UserContext:DbContext
    {

        public DbSet<User> Users { get; set; }

        public UserContext()
        {
            Users = new EntityDataModel().Users;
        }
    }
}