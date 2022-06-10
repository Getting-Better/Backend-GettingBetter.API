using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IStudentService
{
    Task<IEnumerable<Student>> ListAsync();
    Task<IEnumerable<Student>> ListByCoachIdAsync(int coachId);
    Task<StudentResponse> SaveAsync(Student student);
    Task<StudentResponse> UpdateAsync(int studentId, Student student);
    Task<StudentResponse> DeleteAsync(int studentId);
}