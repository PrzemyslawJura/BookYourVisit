using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Visits;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class VisitsRepository : IVisitsRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public VisitsRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddVisitAsync(Visit visit)
    {
        await _dbContext.Visits.AddAsync(visit);
    }

    public async Task<Visit?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Visits.FirstOrDefaultAsync(visit => visit.Id == id);
    }

    public async Task<List<Visit?>> ListByServiceIdAsync(Guid serviceId)
    {
        return await _dbContext.Visits
            .AsNoTracking()
            .Where(visit => visit.ServiceId == serviceId)
            .ToListAsync<Visit?>();
    }

    public async Task<List<Visit?>> ListByUserIdAsync(Guid userId)
    {
        return await _dbContext.Visits
            .AsNoTracking()
            .Where(visit => visit.UserId == userId)
            .ToListAsync<Visit?>();
    }

    public Task RemoveVisitAsync(Visit visit)
    {
        _dbContext.Remove(visit);

        return Task.CompletedTask;
    }

    public Task RemoveVisitsAsync(List<Visit> visits)
    {
        _dbContext.RemoveRange(visits);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Visit visit)
    {
        _dbContext.Update(visit);

        return Task.CompletedTask;
    }
}
