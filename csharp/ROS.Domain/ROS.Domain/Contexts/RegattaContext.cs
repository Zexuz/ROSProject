using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class RegattaContext : MasterContext
    {
        public virtual DbSet<Regatta> Regattas { get; set; }

        public RegattaContext()
        {
            Regattas = Context.Set<Regatta>();;
        }
    }
}
