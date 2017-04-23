using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ROS.Domain.Interfaces.RepositoryInteraces
{
    internal interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        TEntity FindById(int? id);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        void Dispose();
    }
}