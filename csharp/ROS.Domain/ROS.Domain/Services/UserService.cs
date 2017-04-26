using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ROS.Domain.Contexts;
using ROS.Domain.Interfaces.ContextInterfaces;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public class UserService
    {
        private readonly IRosContext<User> _userContext;

        public UserService(IRosContext<User> userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.DbSet;
        }

        public User Add(User user)
        {
            if (!isUserValid(user))
                throw new ArgumentException();

            var returnedUser = _userContext.DbSet.Add(user);
            _userContext.Context.SaveChanges();
            return returnedUser;
        }


        private bool isUserValid(User user)
        {
            //todo validate user
            return true;
        }

        public User Remove(User user)
        {
            var removedUser = _userContext.DbSet.Remove(user);
            _userContext.Context.SaveChanges();
            return removedUser;
        }

        public User Edit(User user)
        {
            var dbUser = _userContext.DbSet.SingleOrDefault(u => u.Id == user.Id);

            if (dbUser == null)
            {
                throw new Exception("Can't find user in db!");
            }

            dbUser.AddressContactId = user.AddressContactId;
            dbUser.DateOfBirth = user.DateOfBirth;
            dbUser.Email = user.Email;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Password = user.Password;
            _userContext.Context.SaveChanges();

            return user;
        }
    }
}