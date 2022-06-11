using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Domain.Repositories;

public interface ITournamentRepository
{
    Task<IEnumerable<Tournament>> ListAsync();
    Task AddAsync(Tournament tournament);
    Task<Tournament> FindByIdAsync(int id);
    void Update(Tournament tournament);
    void Remove(Tournament tournament);
 
}