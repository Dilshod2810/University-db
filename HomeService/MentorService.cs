using Dapper;
using Npgsql;

namespace University.HomeService;

public class MentorService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=University_db;User Id=postgres;Password=2810;";

    public List<Mentor> GetAllMentors()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from mentors";
            var mentors=connection.Query<Mentor>(sql).ToList();
            return mentors;
        }
    }

    public Mentor GetMentorById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from mentors where id=@id;";
            var chosenMentor = connection.QueryFirst(sql, new { Id = id });
            return chosenMentor;
        }
    }

    public bool AddMentor(Mentor mentor)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into mentors(fullname, age, subject, age, email, phone, description ) values(@fullname, @age, @subject, @email, @phone, @description);";
            var addedMentor = connection.Execute(sql, mentor);
            return addedMentor > 0;
        }
    }

    public bool UpdateMentor(Mentor mentor)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "update mentors set fullname=@fullname, age=@age, subject=@subject, email=@email, phone=@phone, description=@description where id=@id;";
            var updatedMentor = connection.Execute(sql, mentor);
            return updatedMentor > 0;
        }
    }

    public bool DeleteMentor(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from mentors where id=@id";
            var deletedMentor = connection.Execute(sql, new{Id=id});
            return deletedMentor > 0;
        }
    }
}