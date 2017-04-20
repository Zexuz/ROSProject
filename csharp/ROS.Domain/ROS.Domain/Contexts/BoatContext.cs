using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class BoatContext : MasterContext
    {
        public virtual DbSet<Boat> Boats{ get; set; }

        public BoatContext()
        {
            Boats = Context.Set<Boat>();
        }
    }
}
