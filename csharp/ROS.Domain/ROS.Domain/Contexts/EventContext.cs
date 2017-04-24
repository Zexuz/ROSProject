using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class EventContext : MasterContext
    {
        public virtual DbSet<Event> Events { get; set; }

        public EventContext()
        {
            Events = Context.Set<Event>();
        }
    }
}