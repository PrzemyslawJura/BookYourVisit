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

    public async Task<List<Salon?>> ListSalonsAsync(int page, int pageSize)
    {
        return await _dbContext.Salons
            .Include(salon => salon.Address)
            .Include(salon => salon.Workers)
                .ThenInclude(worker => worker.Services)
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
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
