using System.Data.SqlClient;
using System.Linq;
using ROS.Models;
using ROS.Services.Interfaces;

namespace ROS.Services
{
    public class UserQueryService : IQueryService<User>
    {
        public string GetSelecByIdQuery(int id)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Users WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);


            var query = SqlCommandToQueryString(cmd);

            return query;
        }

        public string GetDeleteByIdQuery(int id)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Users WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);


            var query = SqlCommandToQueryString(cmd);

            return query;
        }


        public string GetUpdateQuery(User user)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Users SET AddressContactId = @addressContactId, Email = '@email', Password = '@password', FirstName = '@firstName', "+
                              "LastName = '@lastName', DateOfBirth = '@doa' WHERE Id = @id";
            cmd.Parameters.AddWithValue("@addressContactId", user.AddressContactId);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@firstName", user.Name.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.Name.LastName);
            cmd.Parameters.AddWithValue("@doa", user.DateOfBirth.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@id", user.Id);

            var query = SqlCommandToQueryString(cmd);
            return query;
        }

        public string GetInsertQuery(User user)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Users (AddressContactId, Email, Password, FirstName, LastName, DateOfBirth) VALUES " +
                              "(1, '@email', '@password', '@firstName', '@lastName', '@doa')";

            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@firstName", user.Name.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.Name.LastName);
            cmd.Parameters.AddWithValue("@doa", user.DateOfBirth.ToString("yyyy-MM-dd"));

            var query = SqlCommandToQueryString(cmd);
            return query;
        }

        public string GetSelectAllQuery()
        {
            return "SELECT * FROM Users";
        }

        private static string SqlCommandToQueryString(SqlCommand cmd)
        {
            var query = cmd.CommandText;
            foreach (SqlParameter p in cmd.Parameters)
            {
                query = query.Replace(p.ParameterName, p.Value.ToString());
            }
            return query;
        }
    }
}