using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class ClubContext : DbContext
    {
        public virtual EntityDataModel Context { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }

        public ClubContext()
        {
            Context = new EntityDataModel();
            Clubs = Context.Set<Club>();         
        }
    }
}
