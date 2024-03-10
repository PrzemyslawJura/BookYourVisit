using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Salons;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class SalonsRepository : ISalonsRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public SalonsRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddSalonAsync(Salon salon)
    {
        await _dbContext.Salons.AddAsync(salon);
    }

    public async Task<int> Count()
    {
        return await _dbContext.Salons.CountAsync();
    }

    public async Task<Salon?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Salons.FirstOrDefaultAsync(salon => salon.Id == id);
    }

    public async Task<List<Salon?>> ListSalonsAsync(int skip, int take)
    {
        return await _dbContext.Salons
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync<Salon?>();
    }

    public Task RemoveReviewAsync(Salon salon)
    {
        _dbContext.RemoveRange(salon);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Salon salon)
    {
        _dbContext.RemoveRange(salon);

        return Task.CompletedTask;
    }
}
