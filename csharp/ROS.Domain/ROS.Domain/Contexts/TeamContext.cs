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
    public class TeamContext : MasterContext
    {
        public virtual DbSet<Team> Team { get; set; }

        public TeamContext()
        {
            Team = Context.Set<Team>();
        }

    }
}
