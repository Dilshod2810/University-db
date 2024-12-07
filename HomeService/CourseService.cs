using Dapper;
using Npgsql;
using University.DataContext;

namespace University.HomeService;

public class CourseService
{
    DapperContext dapperContext;

    public CourseService()
    {
        dapperContext = new DapperContext();
    }

    public List<Course> GetAllCourse()
    {
        var sql = "select * from courses";
        var courses = dapperContext.Connection().Query<Course>(sql).ToList();
        return courses;
    }

    public Course GetCourseById(int id)
    {
        var sql = "select * from courses where id=@id;";
        var chosenCourse = dapperContext.Connection().QueryFirst(sql, new { Id = id });
        return chosenCourse;
    }

    public bool AddCourse(Course course)
    {
        var sql = "insert into courses(name, description) values(@name,@description);";
        var courses = dapperContext.Connection().Execute(sql, course);
        return courses > 0;
    }

    public bool UpdateCourse(Course course)
    {
        var sql = "update courses set name=@name, description=@description where id=@id;";
        var updatedCourse = dapperContext.Connection().Execute(sql, course);
        return updatedCourse > 0;
    }

    public bool DeleteCourse(int id)
    {
        var sql = "delete from courses where id=@id;";
        var deletedCourse = dapperContext.Connection().Execute(sql, new { Id = id });
        return deletedCourse > 0;
    }
}