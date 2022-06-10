using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class StudentResponse : BaseResponse<Student>
{
    public StudentResponse(string message) : base(message)
    {
    }

    public StudentResponse(Student resource) : base(resource)
    {
    }
}