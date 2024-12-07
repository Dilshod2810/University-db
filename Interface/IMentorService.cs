namespace University.Interface;

public interface IMentorService
{
    List<Mentor> GetAllMentors();
    Mentor? GetMentorById(int id);
    bool AddMentor(Student student);
    bool UpdateMentor(Student student);
    bool DeleteMentor(int id);
}