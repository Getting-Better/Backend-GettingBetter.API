using LearningCenter.API.GettingBetter_System.Domain.Services.Communication;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Domain.Services;

public interface IAdvisoryService
{
    Task<IEnumerable<Advisory>> ListAsync();
    Task<AdvisoryResponse> SaveAsync(Advisory advisory);
    Task<AdvisoryResponse> UpdateAsync(int id, Advisory advisory);
    Task<AdvisoryResponse> DeleteAsync(int id); 
}