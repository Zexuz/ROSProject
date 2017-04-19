using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class RaceEventContext
    {
        public virtual DbSet<RaceEvent> RaceEvents { get; set; }

        public RaceEventContext()
        {
            RaceEvents = new EntityDataModel().RaceEvents;
        }
    }
}