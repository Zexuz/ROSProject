using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class AddressContactContext : DbContext
    {
        public virtual DbSet<AddressContact> AddressContacts { get; set; }

        public AddressContactContext()
        {
            AddressContacts = new EntityDataModel().AddressContacts;
        }
    }
}
