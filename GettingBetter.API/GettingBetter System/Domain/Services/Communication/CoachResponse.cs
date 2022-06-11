using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.GettingBetter_System.Domain.Services.Communication;

public class CoachResponse : BaseResponse<Coach>
{
    public CoachResponse(string message) : base(message)
    {
    }

    public CoachResponse(Coach resource) : base(resource)
    {
    }
}