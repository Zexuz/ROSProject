﻿using System.Data.SqlClient;
using ROS.Interfaces;
using ROS.Models;

namespace ROS
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly MSSQLLoginCredentials _loginCredentialsCred;

        public DatabaseConnection(MSSQLLoginCredentials loginCredentialsCred)
        {
            _loginCredentialsCred = loginCredentialsCred;
        }

        public SqlCommand PrepareQuery(string query)
        {
            var connectionString = $@"Data Source={_loginCredentialsCred.Host};
                                   Initial Catalog={_loginCredentialsCred.Database};
                                   User id={_loginCredentialsCred.LoginName};
                                   Password={_loginCredentialsCred.Password};";
            using (var conn = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, conn);
                return command;
            }
        }
    }
}