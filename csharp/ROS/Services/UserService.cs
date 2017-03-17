using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ROS.Models;
using ROS.Repositories.Interfaces;

namespace ROS.Services
{
    public class UserService:IServiceReposetory<User>
    {
        public List<User> GetAll()
        {
            var getAllQuery = new UserQueryService().GetSelectAllQuery();
            var data = SendQuery(getAllQuery);

            //todo handel data
            //todo return data

            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(User type)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(User type)
        {
            throw new System.NotImplementedException();
        }

        public SqlDataReader SendQuery(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}