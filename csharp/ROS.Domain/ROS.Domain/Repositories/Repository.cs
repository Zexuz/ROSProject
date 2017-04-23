using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using ROS.Domain.Contexts;
using ROS.Domain.Interfaces;
using ROS.Domain.Interfaces.ContextInterfaces;
using ROS.Domain.Interfaces.RepositoryInteraces;

namespace ROS.Domain.Repositories
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly IRosContext<TEntity> _context;

        public Repository()
        {
            _context = new RosContext<TEntity>();
        }
        public Repository(IRosContext<TEntity> context)
        {
            if(context == null) throw new ArgumentNullException();
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Context.Set<TEntity>().Add(entity);
            _context.Context.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Context.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            //if (FindById(entity.Id) == null) throw new NullReferenceException();
            ////_context.DbSet.Attach(entity);
            _context.Context.Set<TEntity>().AddOrUpdate(entity);
            //_context.Context.Entry(entity).State = EntityState.Modified;
            _context.Context.SaveChanges();
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            var removed = _context.Context.Set<TEntity>().Remove(entity);
            _context.Context.SaveChanges();
            return removed;
        }

        public TEntity FindById(int? id)
        {
            return _context.Context.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public TEntity FindByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Context.Set<TEntity>().Where(predicate);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
