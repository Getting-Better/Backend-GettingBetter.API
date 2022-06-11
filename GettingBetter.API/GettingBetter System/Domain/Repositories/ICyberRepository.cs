using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Domain.Repositories;

public interface ICyberRepository
{
    Task<IEnumerable<Cyber>> ListAsync();
    Task AddAsync(Cyber cyber);
    Task<Cyber> FindByIdAsync(int id);
    void Update(Cyber cyber);
    void Remove(Cyber cyber);
}