using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class ContactPersonContext : MasterContext
    {
        public virtual DbSet<ContactPerson> ContactPersons{ get; set; }

        public ContactPersonContext()
        {
            ContactPersons = Context.Set<ContactPerson>();
        }
    }
}
