using LearningCenter.API.GettingBetter_System.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.GettingBetter_System.Persistence.Repositories;

public class TournamentRepository : BaseRepository, ITournamentRepository
{
    public TournamentRepository(AppDbContext context) : base(context)
    { 
    }

    public async Task<IEnumerable<Tournament>> ListAsync()
    {
        return await _context.Tournaments.ToListAsync();
    }

    public async Task AddAsync(Tournament tournament)
    {
        await _context.Tournaments.AddAsync(tournament);
    }

    public async Task<Tournament> FindByIdAsync(int id)
    {
        return await _context.Tournaments.FindAsync(id);
    }

    public void Update(Tournament tournament)
    {
        _context.Tournaments.Update(tournament);
    }

    public void Remove(Tournament coach)
    {
        _context.Tournaments.Remove(coach);
    }
}