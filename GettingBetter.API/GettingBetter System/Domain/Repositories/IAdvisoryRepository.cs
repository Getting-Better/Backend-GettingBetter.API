using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Domain.Repositories;

public interface IAdvisoryRepository
{
    Task<IEnumerable<Advisory>> ListAsync();
    Task AddAsync(Advisory advisory);
    Task<Advisory> FindByIdAsync(int id);
    void Update(Advisory advisory);
    void Remove(Advisory advisory);

}