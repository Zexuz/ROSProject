using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class TeamCrewRegisteredUserContext : MasterContext
    {
        public virtual DbSet<TeamCrewRegisteredUser> TeamCrewRegisteredUser { get; set; }

        public TeamCrewRegisteredUserContext()
        {
            TeamCrewRegisteredUser = Context.Set<TeamCrewRegisteredUser>();
        }

    }
}
