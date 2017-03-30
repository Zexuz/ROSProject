using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class EntryContext:DbContext
    {
        public DbSet<Entry> Entries { get; set; }

        public EntryContext()
        {
            Entries = new EntityDataModel().Entries;
        }
    }
}