using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Domain.Interfaces.ContextInterfaces;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class RosContext<TEntity> : IRosContext<TEntity> where TEntity : class
    {
        public EntityDataModel Context { get; set; }
        public DbSet<TEntity> DbSet { get; set; }

        public RosContext()
        {
            Context = new EntityDataModel();
            DbSet = Context.Set<TEntity>();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        
    }
}
