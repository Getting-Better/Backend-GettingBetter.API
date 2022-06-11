using LearningCenter.API.GettingBetter_System.Domain.Services.Communication;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.GettingBetter_System.Domain.Services;

public interface ICoachService
{
    Task<IEnumerable<Coach>> ListAsync();
    Task<CoachResponse> SaveAsync(Coach coach);
    Task<CoachResponse> UpdateAsync(int id, Coach coach);
    Task<CoachResponse> DeleteAsync(int id);
}