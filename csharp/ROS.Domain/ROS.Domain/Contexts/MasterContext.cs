using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public abstract class MasterContext:DbContext, IContext
    {
        public EntityDataModel Context { get; set; }

        protected MasterContext()
        {
            Context = new EntityDataModel();
        }
    }
}