using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class RegisteredUserContext : DbContext
    {

        public virtual EntityDataModel Context { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }

        public RegisteredUserContext()
        {
            Context = new EntityDataModel();
            RegisteredUsers = Context.Set<RegisteredUser>();
        }
    }
}
