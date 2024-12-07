namespace University.Interface;

public interface IGroupService
{
    List<IGroupService> GetAllGroups();
    IGroupService? GetGroupById(int id);
    bool AddGroup(Group group);
    bool UpdateGroup(Group group);
    bool DeleteGroup(int id);
}