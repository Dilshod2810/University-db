namespace University.Interface;

public interface ICourseService
{
    List<Course> GetAllCourse();
    Course GetCourseById(int id);
    bool AddCourse(Course course);
    bool UpdateCourse(Course course);
    bool DeleteCourse(int id);
}