using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class EntryContext:DbContext
    {
        public virtual DbSet<Entry> Entries { get; set; }

        public EntryContext()
        {
            Entries = new EntityDataModel().Entries;
        }
    }
}