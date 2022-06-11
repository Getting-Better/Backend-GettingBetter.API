using LearningCenter.API.GettingBetter_System.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.GettingBetter_System.Persistence.Repositories;

public class CyberRepository : BaseRepository, ICyberRepository
{
    public CyberRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Cyber>> ListAsync()
    {
        return await _context.Cybers.ToListAsync();
    }

    public async Task AddAsync(Cyber cyber)
    {
        await _context.Cybers.AddAsync(cyber);
    }

    public async Task<Cyber> FindByIdAsync(int id)
    {
        return await _context.Cybers.FindAsync(id);
    }

    public void Update(Cyber cyber)
    {
        _context.Cybers.Update(cyber);
    }

    public void Remove(Cyber cyber)
    {
        _context.Cybers.Remove(cyber);
    } 
}