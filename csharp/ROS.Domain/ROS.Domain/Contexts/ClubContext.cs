using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class ClubContext : MasterContext
    {      
        public virtual DbSet<Club> Clubs { get; set; }

        public ClubContext()
        {       
            Clubs = Context.Set<Club>();         
        }

      //  public System.Data.Entity.DbSet<ROS.Domain.Models.AddressContact> AddressContacts { get; set; }

        // public System.Data.Entity.DbSet<ROS.Domain.Models.AddressContact> AddressContacts { get; set; }
    }
}
