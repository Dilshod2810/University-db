using Dapper;
using Npgsql;

namespace University.HomeService;

public class StudentService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=University_db;User Id=postgres;Password=2810;";

    public List<Student> GetAllStudent()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from students;";
            var result = connection.Query<Student>(sql).ToList();
            return result;
        }
    }

    public Student GetStudentById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from students where id=@id;";
            var result = connection.QueryFirstOrDefault<Student>(sql, new { id });
            return result;
        }
    }

    public bool AddStudent(Student student)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql =
                "insert into students(fullname,age, email,phone, description) values(@fullname,@age,@email,@phone,@description);";
            var addedStudent = connection.Execute(sql, student);
            return addedStudent > 0;
        }
    }

    public bool UpdateStudent(Student student)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql =
                "update students set fullname=@fullname, age=@age, email=@email, phone=@phone, description=@description;";
            var updatedStudent = connection.Execute(sql, student);
            return updatedStudent > 0;
        }
    }

    public bool DeleteStudent(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from students where id = @id";
            var deletedStudent = connection.Execute(sql, new { Id = @id });
            return deletedStudent > 0;
        }
    }
}