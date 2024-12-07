using Dapper;
using Npgsql;
using University.DataContext;

namespace University.HomeService;

public class MentorService
{
    DapperContext dapperContext;
    public MentorService()
    {
        dapperContext = new DapperContext();
    }

    public List<Mentor> GetAllMentors()
    {
            var sql = "select * from mentors";
            var mentors=dapperContext.Connection().Query<Mentor>(sql).ToList();
            return mentors;
        
    }

    public Mentor GetMentorById(int id)
    {
            var sql = "select * from mentors where id=@id;";
            var chosenMentor = dapperContext.Connection().QueryFirst(sql, new { Id = id });
            return chosenMentor;
        
    }

    public bool AddMentor(Mentor mentor)
    {
            var sql = "insert into mentors(fullname, age, subject, age, email, phone, description ) values(@fullname, @age, @subject, @email, @phone, @description);";
            var addedMentor = dapperContext.Connection().Execute(sql, mentor);
            return addedMentor > 0;
        
    }

    public bool UpdateMentor(Mentor mentor)
    {
            var sql = "update mentors set fullname=@fullname, age=@age, subject=@subject, email=@email, phone=@phone, description=@description where id=@id;";
            var updatedMentor = dapperContext.Connection().Execute(sql, mentor);
            return updatedMentor > 0;
        
    }

    public bool DeleteMentor(int id)
    {
        
            var sql = "delete from mentors where id=@id";
            var deletedMentor = dapperContext.Connection().Execute(sql, new{Id=id});
            return deletedMentor > 0;
        
    }
}