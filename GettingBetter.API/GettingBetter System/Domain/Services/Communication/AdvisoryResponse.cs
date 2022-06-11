using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.GettingBetter_System.Domain.Services.Communication;

public class AdvisoryResponse : BaseResponse<Advisory>
{
    public AdvisoryResponse(string message) : base(message)
    {
    }

    public AdvisoryResponse(Advisory resource) : base(resource)
    {
    }

}