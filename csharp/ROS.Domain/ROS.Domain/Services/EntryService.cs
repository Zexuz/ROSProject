
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ROS.Domain.Contexts;
using ROS.Domain.Interfaces;
using ROS.Domain.Interfaces.ContextInterfaces;
using ROS.Domain.Models;
using ROS.Domain.Repositories;

namespace ROS.Domain.Services
{
    public class EntryService
    {        
        private readonly Repository<Entry> _repository;

        public EntryService()
        {
            _repository = new Repository<Entry>();
        }

        public EntryService(IRosContext<Entry> context)
        {
            _repository = new Repository<Entry>(context);
        }
        
        public IEnumerable GetAll()
        {
            return _repository.GetAll();
        }

        public Entry Add(Entry entry)
        {
            var returnedEntry = _repository.Add(entry);
            return returnedEntry;
        }

        public Entry Remove(Entry entry)
        {
            var removedEntry = _repository.Remove(entry);
            return removedEntry;
        }

        public Entry Edit(Entry entry)
        {
            var entryExistsInDb = _repository.FindById(entry.Id);
            if (entryExistsInDb == null) throw new NullReferenceException();
            var dbEntry = _repository.Update(entry);
            return dbEntry;
        }

        public Entry GetById(int? id)
        {
            return _repository.FindById(id);
        }

        public Entry GetByEntryNumber(int entryNumber)
        {
            return _repository.FindByPredicate(e => e.Number == entryNumber);
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

            var entryResult = _repository.FindByPredicate(e => e.Number == randomEntry);

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
