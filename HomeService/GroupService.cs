using Npgsql;
using Dapper;
namespace University.HomeService;

public class GroupService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=University_db;User Id=postgres;Password=2810;";

    public List<Group> GetAllGroups()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from groups";
            var groups = connection.Query<Group>(sql).ToList();
            return groups;
        }
    }

    public Group GetGroupById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from groups where id=@id;";
            var chosenGroup = connection.QueryFirst(sql, new{Id=id});
            return chosenGroup;
        }
    }

    public bool AddGroup(Group group)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into groups(name, description) values(@name, @description);";
            var addedGroup = connection.Execute(sql, group);
            return addedGroup > 0;
        }
    }

    public bool UpdateGroup(Group group)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "update groups set name=@name, description=@description;";
            var updatedGroup=connection.Execute(sql, group);
            return updatedGroup > 0;
        }
    }

    public bool DeleteGroup(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from groups where id=@id";
            var deletedGroup=connection.Execute(sql, id);
            return deletedGroup > 0;
        }
    }
}