using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class EntryContext:MasterContext
    {

        public virtual DbSet<Entry>Entries { get; set; }


        public EntryContext()
        {
            Entries = Context.Set<Entry>();
        }
        
    }
}