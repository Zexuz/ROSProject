using System;
using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Interfaces.ContextInterfaces
{
    public interface IRosContext<TEntity> where TEntity : class
    {
        EntityDataModel Context { get; set; }
        DbSet<TEntity> DbSet { get; set; }
        void Dispose();
    }
}