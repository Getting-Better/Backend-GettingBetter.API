using LearningCenter.API.GettingBetter_System.Domain.Services.Communication;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Domain.Services;

public interface ITournamentService
{
    Task<IEnumerable<Tournament>> ListAsync();
    Task<TournamentResponse> SaveAsync(Tournament tournament);
    Task<TournamentResponse> UpdateAsync(int id, Tournament tournament);
    Task<TournamentResponse> DeleteAsync(int id); 
}