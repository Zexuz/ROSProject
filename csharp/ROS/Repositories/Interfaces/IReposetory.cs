using System.Collections.Generic;
using System.Data.SqlClient;

namespace ROS.Repositories.Interfaces
{
    public interface IReposetory<TType>
    {

        List<TType> GetAll();
        TType GetById(int id);
        bool RemoveById(int id);
        SqlDataReader SendQuery(string query);

    }
}