using Dapper;
using Npgsql;
using University.DataContext;

namespace University.HomeService;

public class StudentService
{
    
    DapperContext dapperContext;
    public StudentService()
    {
        dapperContext = new DapperContext();
    }

    public List<Student> GetAllStudent()
    {
            var sql = "select * from students;";
            var result = dapperContext.Connection().Query<Student>(sql).ToList();
            return result;
        
    }

    public Student GetStudentById(int id)
    {
            var sql = "select * from students where id=@id;";
            var result = dapperContext.Connection().QueryFirstOrDefault<Student>(sql, new { id });
            return result;
        
    }

    public bool AddStudent(Student student)
    {
            var sql =
                "insert into students(fullname,age, email,phone, description) values(@fullname,@age,@email,@phone,@description);";
            var addedStudent = dapperContext.Connection().Execute(sql, student);
            return addedStudent > 0;
        
    }

    public bool UpdateStudent(Student student)
    {
        
            var sql =
                "update students set fullname=@fullname, age=@age, email=@email, phone=@phone, description=@description;";
            var updatedStudent = dapperContext.Connection().Execute(sql, student);
            return updatedStudent > 0;
        
    }

    public bool DeleteStudent(int id)
    {
            var sql = "delete from students where id = @id";
            var deletedStudent = dapperContext.Connection().Execute(sql, new { Id = @id });
            return deletedStudent > 0;
        
    }
}