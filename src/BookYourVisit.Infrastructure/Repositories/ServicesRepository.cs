using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Services;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class ServicesRepository : IServicesRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public ServicesRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddServiceAsync(Service service)
    {
        await _dbContext.Services.AddAsync(service);
    }

    public async Task<Service?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Services.FindAsync(id);
    }

    public async Task<List<Service?>> ListByWorkerIdAsync(Guid workerId)
    {
        return await _dbContext.Services
            .AsNoTracking()
            .Where(service => service.WorkerId == workerId)
            .ToListAsync<Service?>();
    }

    public Task RemoveServiceAsync(Service service)
    {
        _dbContext.Remove(service);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Service service)
    {
        _dbContext.Update(service);

        return Task.CompletedTask;
    }
}
