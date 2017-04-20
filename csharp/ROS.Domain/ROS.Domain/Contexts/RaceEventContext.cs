using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class RaceEventContext:MasterContext
    {
        public virtual DbSet<RaceEvent> RaceEvents { get; set; }

        public RaceEventContext()
        {
            RaceEvents = Context.Set<RaceEvent>();
        }
    }
}