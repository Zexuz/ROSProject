
namespace ROS.Services.Interfaces
{
    public interface IQueryService<in TType>
    {

        string GetSelecByIdQuery(int id);
        string GetDeleteByIdQuery(int id);
        string GetUpdateQuery(TType type);
        string GetInsertQuery(TType type);
        string GetSelectAllQuery();

    }
}