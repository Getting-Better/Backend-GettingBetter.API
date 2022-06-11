using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.GettingBetter_System.Domain.Services.Communication;

public class TournamentResponse :BaseResponse<Tournament>
{
    public TournamentResponse(string message) : base(message)
    {
    }

    public TournamentResponse(Tournament resource) : base(resource)
    {
    }
}