using LearningCenter.API.GettingBetter_System.Domain.Services.Communication;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Domain.Services;

public interface ICyberService
{
    Task<IEnumerable<Cyber>> ListAsync();
    Task<CyberResponse> SaveAsync(Cyber cyber);
    Task<CyberResponse> UpdateAsync(int id, Cyber cyber);
    Task<CyberResponse> DeleteAsync(int id);
}
