using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ROS.Exceptions;
using ROS.Extensions;
using ROS.Models;
using ROS.Repositories.Interfaces;


namespace ROS.Repositories
{
    public class MasterReposetory<TType> : IReposetory<TType>
    {
        private readonly IDatabaseConnection _databaseConnection;
        private readonly string _tableName;

        public MasterReposetory(IDatabaseConnection databaseConnection, string tableName)
        {
            _databaseConnection = databaseConnection;
            _tableName = tableName;
        }

        public List<TType> GetAll()
        {
            SqlCommand command = _databaseConnection.PrepareQuery($"SELECT * FROM {_tableName}");
            return GetData(command);
        }

        public TType GetById(int id)
        {
            SqlCommand command = _databaseConnection.PrepareQuery($"SELECT * FROM {_tableName} WHERE Id = {id}");
            return GetData(command).FirstOrDefault();
        }

        public bool RemoveById(int id)
        {
            SqlCommand command = _databaseConnection.PrepareQuery($"DELETE FROM {_tableName} WHERE Id = {id}");
            var numberOfRecords = command.ExecuteNonQuery();
            return numberOfRecords == 1;
        }

        public bool Insert(TType type)
        {
            throw new NotImplementedException();
        }

        public bool Update(TType type)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader SendQuery(string query)
        {
            SqlCommand command = _databaseConnection.PrepareQuery(query);
            return command.ExecuteReader();
        }

        private List<TType> GetData(SqlCommand command)
        {
            var @switch = new Dictionary<Type, Func<SqlCommand, List<TType>>>
            {
                {typeof(User), GetUserFromSqlReder}
            };

            try
            {
                return @switch[typeof(TType)].Invoke(command);
            }
            catch (Exception e)
            {
                throw new TypeNotImplementedException($"The type {typeof(TType)} is not implimented");
            }
        }

        private List<TType> GetUserFromSqlReder(SqlCommand command)
        {
            var objectTypes = new List<TType>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.HasRows)
                {
                    dynamic user = new User();

                    user.DateOfBirth = reader.GetDateTimeNullCheck(6);
                    user.Email = reader.GetStringNullCheck(2);
                    user.Id = reader.GetIntNullCheck(0);
                    user.AddressContactId = reader.GetIntNullCheck(1);
                    user.Name.FirstName = reader.GetStringNullCheck(4);
                    user.Name.LastName = reader.GetStringNullCheck(5);
                    user.Password = reader.GetStringNullCheck(3);
                    objectTypes.Add(user);
                }
            }
            return objectTypes;
        }
    }
}