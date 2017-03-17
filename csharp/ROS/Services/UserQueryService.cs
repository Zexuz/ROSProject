using ROS.Models;
using ROS.Repositories;

namespace ROS.Services
{
    public class UserQueryService:IQueryService<User>
    {
        public string GetSelecByIdQuery(User user)
        {
            throw new System.NotImplementedException();
        }

        public string GetDeleteQuery(User user)
        {
            throw new System.NotImplementedException();
        }

        public string GetUpdateQuery(User user)
        {
            throw new System.NotImplementedException();
        }

        public string GetInsertQuery(User user)
        {
            return "INSERT INTO Users (AddressContactId, Email, Password, FirstName, LastName, DateOfBirth) VALUES "+
                   $"(1, '{user.Email}', '{user.Password}', '{user.Name.FirstName}', '{user.Name.LastName}', '{user.DateOfBirth:yyyy-MM-dd}');";
        }
    }
}