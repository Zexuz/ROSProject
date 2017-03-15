using System.Data.SqlClient;

namespace ROS.Repositories.Interfaces
{
    public interface IDatabaseConnection
    {
        SqlCommand PrepareQuery(string query);


    }
}