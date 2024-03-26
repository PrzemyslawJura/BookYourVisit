using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Workers;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class WorkersRepository : IWorkersRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public WorkersRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddWorkerAsync(Worker worker)
    {
        await _dbContext.Workers.AddAsync(worker);
    }

    public async Task<Worker?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Workers.FindAsync(id);
    }

    public async Task<List<Worker?>> ListBySalonIdAsync(Guid salonId)
    {
        return await _dbContext.Workers
            .AsNoTracking()
            .Where(worker => worker.SalonId == salonId)
            .ToListAsync<Worker?>();
    }

    public Task RemoveWorkerAsync(Worker worker)
    {
        _dbContext.Remove(worker);

        return Task.CompletedTask;
    }

    public Task RemoveWorkersAsync(List<Worker> workers)
    {
        _dbContext.RemoveRange(workers);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Worker worker)
    {
        _dbContext.Update(worker);

        return Task.CompletedTask;
    }
}
