using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class UserContext : DbContext
    {
        public virtual EntityDataModel Context { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public UserContext()
        {
            Context = new EntityDataModel();
            Users = Context.Set<User>();
        }
    }
}