using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface ICoachService
{
    Task<IEnumerable<Coach>> ListAsync();
    Task<CoachResponse> SaveAsync(Coach coach);
    Task<CoachResponse> UpdateAsync(int id, Coach coach);
    Task<CoachResponse> DeleteAsync(int id);
}