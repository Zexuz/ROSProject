using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Test
{
    public class SocialEventContext
    {
        public virtual DbSet<SocialEvent> SocialEvents { get; set; }

        public SocialEventContext()
        {
            SocialEvents = new EntityDataModel().SocialEvents;
        }
    }
}