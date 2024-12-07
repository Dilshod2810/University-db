using Dapper;
using Npgsql;

namespace University.HomeService;

public class CourseService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=University_db;User Id=postgres;Password=2810;";

    public List<Course> GetAllCourse()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from courses";
            var courses = connection.Query<Course>(sql).ToList();
            return courses;
        }
    }

    public Course GetCourseById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from courses where id=@id;";
            var chosenCourse = connection.QueryFirst(sql, new { Id = id });
            return chosenCourse;
        }
    }

    public bool AddCourse(Course course)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into courses(name, description) values(@name,@description);";
            var courses = connection.Execute(sql, course);
            return courses > 0;
        }
    }

    public bool UpdateCourse(Course course)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "update courses set name=@name, description=@description where id=@id;";
            var updatedCourse = connection.Execute(sql, course);
            return updatedCourse > 0;
        }
    }

    public bool DeleteCourse(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from courses where id=@id;";
            var deletedCourse = connection.Execute(sql, new { Id = id });
            return deletedCourse > 0;
        }
    }
}