
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

        public Entry GetByEntryNumber(int entryNumber)
        {
            return _context.Entries.First(e => e.Number == entryNumber);
        }

        private Random random = new Random();

        public int GetEntryNumber()
        {
            var nr = RandomEntryNrCreator();
            while (CheckIfEntryExists(nr))
            {
                nr = RandomEntryNrCreator();
            }

            return nr;
        }

        public int RandomEntryNrCreator()
        {
            var newString = "";

            const string chars = "123456789";

            newString = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());




            return int.Parse(newString);
        }

        public bool CheckIfEntryExists(int RandomEntryNr)
        {
            var randomEntry = RandomEntryNr;

            var entryResult = GetAll().Select(e => e.Number == randomEntry);

            if (entryResult != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
