using System.Data.SqlClient;
using ROS.Models;
using ROS.Repositories.Interfaces;

namespace ROS.Repositories
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly MsSqlLoginCredentials _loginCredentialsCred;

        public DatabaseConnection(MsSqlLoginCredentials loginCredentialsCred)
        {
            _loginCredentialsCred = loginCredentialsCred;
        }

        public SqlCommand PrepareQuery(string query)
        {
            var connectionString = $@"Data Source={_loginCredentialsCred.Host};
                                   Initial Catalog={_loginCredentialsCred.Database};
                                   User id={_loginCredentialsCred.LoginName};
                                   Password={_loginCredentialsCred.Password};";
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var command = new SqlCommand(query, conn);
            return command;
        }
    }
}