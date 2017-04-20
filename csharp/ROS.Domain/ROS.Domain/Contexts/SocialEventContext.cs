using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class SocialEventContext:MasterContext
    {
        public virtual DbSet<SocialEvent> SocialEvents { get; set; }

        public SocialEventContext()
        {
            SocialEvents = Context.Set<SocialEvent>();;
        }
    }
}