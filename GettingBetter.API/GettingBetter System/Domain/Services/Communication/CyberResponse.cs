using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.GettingBetter_System.Domain.Services.Communication;

public class CyberResponse : BaseResponse<Cyber>
{
    public CyberResponse(string message) : base(message)
    {
    }

    public CyberResponse(Cyber resource) : base(resource)
    {
    }
}