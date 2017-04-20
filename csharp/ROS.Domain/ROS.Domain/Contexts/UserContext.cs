using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class UserContext : MasterContext
    {
        public virtual DbSet<User> Users { get; set; }

        public UserContext()
        {
            Users = Context.Set<User>();
        }
    }
}