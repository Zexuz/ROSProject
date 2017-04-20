using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class ContactPersonContext : DbContext
    {
        public virtual DbSet<ContactPerson> ContactPersons { get; set; }

        public ContactPersonContext()
        {
            ContactPersons = new EntityDataModel().ContactPersons;
        }
    }
}
