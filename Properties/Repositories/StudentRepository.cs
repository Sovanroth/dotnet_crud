using Microsoft.EntityFrameworkCore;
using MyApi.Properties.Data;
using MyApi.Properties.Model;

namespace MyApi.Properties.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _appDbContext;

    public StudentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<IEnumerable<Student?>> GetAllStudents()
    {
        return await _appDbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentById(int id)
    {
        return await _appDbContext.Students.FindAsync(id);
    }

    public async Task<Student> CreateStudent(Student student)
    {
        _appDbContext.Students.Add(student);
        await _appDbContext.SaveChangesAsync();
        return student;
    }

    public async Task UpdateStudent(Student student)
    {
        _appDbContext.Entry(student).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteStudent(int id)
    {
        var student = await _appDbContext.Students.FindAsync(id);
        _appDbContext.Students.Remove(student);
        await _appDbContext.SaveChangesAsync();
    }
}