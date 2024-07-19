using MyApi.Properties.Model;

namespace MyApi.Properties.Repository;

public interface IStudentRepository
{
    Task<IEnumerable<Student?>> GetAllStudents();
    Task<Student?> GetStudentById(int id);
    Task<Student> CreateStudent(Student student);
    Task UpdateStudent(Student student);
    Task DeleteStudent(int id);
}