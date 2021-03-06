﻿using ROS.Domain.Contexts;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Domain.Repositories;

namespace ROS.Domain.Services
{
    public class RegisteredUserService
    {
        private readonly RegisteredUserContext _registeredUserContext;
        private readonly Repository<RegisteredUser> _repository;

        public RegisteredUserService(RegisteredUserContext registeredUserContext)
        {
            _registeredUserContext = registeredUserContext;
            _repository = new Repository<RegisteredUser>();
        }
        public RegisteredUserService()
        {
            _repository = new Repository<RegisteredUser>();
        }

        public int GetIdByUserIdAndEntryId(int userId, int entryId)
        {
            return _registeredUserContext.RegisteredUsers.SingleOrDefault(r => r.UserId == userId && r.EntryId == entryId).Id;
        }

        public RegisteredUser GetById(int id)
        {
            return _registeredUserContext.RegisteredUsers.SingleOrDefault(r => r.Id == id);
        }

        public int GetUserIdById(int id)
        {
            return _registeredUserContext.RegisteredUsers.SingleOrDefault(r => r.Id == id).UserId;
        }

        public IEnumerable<int> GetAllUserIdsByEntryId(int entryId)
        {
            return _registeredUserContext.RegisteredUsers.Where(r => r.EntryId == entryId).Select(r => r.UserId);            
        }

        public IEnumerable<RegisteredUser> GetAllRegisteredUsersByEntryId(int entryId) //Niclas TODO : Fix everyones services
        {
            return _repository.FindAllByPredicate(r => r.EntryId == entryId);
        }

        public IEnumerable<int> GetAllEntryIdsByUserId(int userId)
        {
            return _registeredUserContext.RegisteredUsers.Where(r => r.UserId == userId).Select(r => r.EntryId);
        }

        public RegisteredUser JoinEntry (int userId, int entryId)
        {
            RegisteredUser newRegisteredUser = new RegisteredUser {UserId = userId, EntryId = entryId };
            RegisteredUser returnedRegisteredUser = _registeredUserContext.RegisteredUsers.Add(newRegisteredUser);
            _registeredUserContext.Context.SaveChanges();
            return returnedRegisteredUser;
        }

        public RegisteredUser Remove (RegisteredUser registeredUser)
        {
            var removedRegisteredUser = _registeredUserContext.RegisteredUsers.Remove(registeredUser);
            _registeredUserContext.Context.SaveChanges();
            return removedRegisteredUser;
        }
    }
}
