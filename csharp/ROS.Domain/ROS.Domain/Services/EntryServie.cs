
using System.Collections.Generic;
using System.Data.Entity;
using ROS.Domain.Contexts;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public class EntryServie
    {
        private readonly EntryContext _context;

        public EntryServie(EntryContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Entry> GetAll()
        {
            return _context.Entries;
        }

        public Entry Add(Entry entry)
        {
            var returnedEntry = _context.Entries.Add(entry);
            _context.Context.SaveChanges();

            return returnedEntry;
        }

        public Entry Remove(Entry entry)
        {
            var removedEntry = _context.Entries.Remove(entry);
            _context.SaveChanges();
            return removedEntry;
        }

        public Entry Edit(Entry entry)
        {
            var editedEntry = _context.Entries.Attach(entry);
            _context.Entry(entry).State = EntityState.Modified;
            _context.SaveChanges();
            return editedEntry;
        }
        
    }
}
