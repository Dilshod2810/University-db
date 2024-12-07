using Npgsql;
using Dapper;
namespace University.HomeService;
using University.DataContext;


public class GroupService
{
    DapperContext dapperContext;
    public GroupService()
    {
        dapperContext = new DapperContext();
    }
    public List<Group> GetAllGroups()
    {
        
            var sql = "select * from groups";
            var groups = dapperContext.Connection().Query<Group>(sql).ToList();
            return groups;
        
    }

    public Group GetGroupById(int id)
    {
            var sql = "select * from groups where id=@id;";
            var chosenGroup = dapperContext.Connection().QueryFirst(sql, new{Id=id});
            return chosenGroup;
        
    }

    public bool AddGroup(Group group)
    {
            var sql = "insert into groups(name, description) values(@name, @description);";
            var addedGroup = dapperContext.Connection().Execute(sql, group);
            return addedGroup > 0;
        
    }

    public bool UpdateGroup(Group group)
    {
      
            var sql = "update groups set name=@name, description=@description;";
            var updatedGroup=dapperContext.Connection().Execute(sql, group);
            return updatedGroup > 0;
        
    }

    public bool DeleteGroup(int id)
    {

            var sql = "delete from groups where id=@id";
            var deletedGroup=dapperContext.Connection().Execute(sql, id);
            return deletedGroup > 0;
        
    }
}