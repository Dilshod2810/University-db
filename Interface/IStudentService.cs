namespace University.Interface;

public interface IStudentService
{
    List<Student> GetAllStudents();
    Student? GetStudentById(int id);
    bool AddStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
}