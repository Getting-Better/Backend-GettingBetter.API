using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class CoachRepository : BaseRepository, ICoachRepository
{
    public CoachRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Coach>> ListAsync()
    {
        return await _context.Coaches.ToListAsync();
    }

    public async Task AddAsync(Coach coach)
    {
        await _context.Coaches.AddAsync(coach);
    }

    public async Task<Coach> FindByIdAsync(int id)
    {
        return await _context.Coaches.FindAsync(id);
    }

    public void Update(Coach coach)
    {
        _context.Coaches.Update(coach);
    }

    public void Remove(Coach coach)
    {
        _context.Coaches.Remove(coach);
    }
}