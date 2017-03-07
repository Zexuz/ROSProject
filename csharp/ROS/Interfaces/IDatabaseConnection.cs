using System;
using System.Data.SqlClient;

namespace ROS.Interfaces
{
    public interface IDatabaseConnection
    {
        string Host { get; set; }
        string Database { get; set; }
        string LoginName { get; set; }
        string Password { get; set; }

        SqlConnection SqlConnection { get; }

        void OpenConnection();
        void CloseConnection();

        object SendQueryOperation();


    }
}