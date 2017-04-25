using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class RaceEntryContext : MasterContext
    {
        public virtual DbSet<RaceEntry> RaceEntry { get; set; }

        public RaceEntryContext()
        {
            RaceEntry = Context.Set<RaceEntry>();
        }
    }
}
