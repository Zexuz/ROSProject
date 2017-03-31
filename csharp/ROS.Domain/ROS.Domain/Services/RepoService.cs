using System.Collections.Generic;
using System.Data.Entity;

namespace ROS.Domain.Services
{

    public class RepoContext<T>:DbContext where T : class
    {

        public virtual DbSet<T> Context { get; set; }

        public RepoContext(DbSet<T> context)
        {
            Context = context;
        }
    }
    
    
    public class RepoService<T> where T : class
    {
        private readonly RepoContext<T> _context;

        public RepoService(RepoContext<T> context)
        {
            _context = context;
        }
        
        public IEnumerable<T> GetAll()
        {
            return _context.Context;
        }

        public T Add(T entity)
        {
            var returnedUser = _context.Context.Add(entity);
            _context.SaveChanges();
            return returnedUser;
        }

        public T Remove(T entity)
        {
            var removedUser = _context.Context.Remove(entity);
            _context.SaveChanges();
            return removedUser;
        }

        public T Edit(T entity)
        {
            var editedUser = _context.Context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return editedUser;
        }
        
        
        


    }
}