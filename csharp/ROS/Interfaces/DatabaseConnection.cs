using System;
using System.Data.SqlClient;

namespace ROS.Interfaces
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        public SqlConnection SqlConnection { get; set; }


        public void Login()

        {
            SqlConnection = new SqlConnection("");
            return SqlConnection;
        }

        void Test()
        {
            using (Login())
            {

            }
        }
    }
}