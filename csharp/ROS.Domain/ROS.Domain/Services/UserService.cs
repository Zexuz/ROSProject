﻿using System.Collections.Generic;
using System.Data.Entity;
using ROS.Domain.Contexts;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public class UserService
    {
        private readonly UserContext _userContext;

        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users;
        }

        public User Add(User user)
        {
            var returnedUser = _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return returnedUser;
        }

        public User Remove(User user)
        {
            var removedUser = _userContext.Users.Remove(user);
            _userContext.SaveChanges();
            return removedUser;
        }

        public User Edit(User user)
        {
            var editedUser = _userContext.Users.Attach(user);
            _userContext.Entry(user).State = EntityState.Modified;
            _userContext.SaveChanges();
            return editedUser;
        }
    }
}