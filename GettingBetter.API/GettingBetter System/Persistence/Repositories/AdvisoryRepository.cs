using LearningCenter.API.GettingBetter_System.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.GettingBetter_System.Persistence.Repositories;

public class AdvisoryRepository : BaseRepository, IAdvisoryRepository
{
     public AdvisoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Advisory>> ListAsync()
    {
        return await _context.Advisories.ToListAsync();
    }

    public async Task AddAsync(Advisory coach)
    {
        await _context.Advisories.AddAsync(coach);
    }

    public async Task<Advisory> FindByIdAsync(int id)
    {
        return await _context.Advisories.FindAsync(id);
    }

    public void Update(Advisory advisory)
    {
        _context.Advisories.Update(advisory);
    }

    public void Remove(Advisory advisory)
    {
        _context.Advisories.Remove(advisory);
    }
}