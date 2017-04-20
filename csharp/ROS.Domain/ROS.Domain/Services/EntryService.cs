
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ROS.Domain.Contexts;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public class EntryService
    {
        private readonly EntryContext _context;

        public EntryService(EntryContext context)
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
            _context.SaveChanges();
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

            var dbEntry = _context.Entries.SingleOrDefault(u => u.Id == entry.Id);

            if (dbEntry == null)
            {
                throw new Exception("Can't find entry in db!");
            }
            dbEntry.BoatId = entry.BoatId;
            dbEntry.SkipperId = entry.SkipperId;
            dbEntry.HasPayed = entry.HasPayed;
            _context.SaveChanges();
            return dbEntry;
        }

        public Entry GetById(int id)
        {
            return _context.Entries.First(e => e.Id == id);
        }
    }
}
