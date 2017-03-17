namespace ROS.Repositories
{
    public interface IQueryService<in TType>
    {

        string GetSelecByIdQuery(TType type);
        string GetDeleteQuery(TType type);
        string GetUpdateQuery(TType type);
        string GetInsertQuery(TType type);

    }
}