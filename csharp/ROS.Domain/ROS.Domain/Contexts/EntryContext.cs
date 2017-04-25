using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class EntryContext : MasterContext
    {
        public virtual DbSet<Entry> Entries { get; set; }


        public EntryContext()
        {
            Entries = Context.Set<Entry>();
        }
        
    }
}