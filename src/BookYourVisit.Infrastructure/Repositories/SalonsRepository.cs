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
        return await _dbContext.Salons.FindAsync(id); //FindAsync zamiast FirstOrDefault, findasync jescli wie ze nic sie na db nie zmienilo to nie robi strzała do db i oddaje ten obiekt działa szybciej 
    }                                                   //Finds an entity with the given primary key values. If an entity with the given primary key values is being tracked by the context, then it is returned immediately without making a request to the database

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
