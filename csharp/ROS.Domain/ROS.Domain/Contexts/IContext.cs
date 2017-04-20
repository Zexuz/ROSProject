using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public interface IContext
    {
        EntityDataModel Context { get; set; }
    }
}