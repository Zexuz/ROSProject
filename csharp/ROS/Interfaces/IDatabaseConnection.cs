using System;
using System.Data.SqlClient;

namespace ROS.Interfaces
{
    public interface IDatabaseConnection
    {
        SqlCommand PrepareQuery(string query);


    }
}