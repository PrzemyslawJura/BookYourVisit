using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Absences;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class AbsencesRepository : IAbsencesRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public AbsencesRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAbsenceAsync(Absence absence)
    {
        await _dbContext.Absences.AddAsync(absence);
    }

    public async Task<Absence?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Absences.FindAsync(id);
    }

    public async Task<List<Absence?>> ListByWorkerIdAsync(Guid workerId)
    {
        return await _dbContext.Absences
            .AsNoTracking()
            .Where(absence => absence.WorkerId == workerId)
            .ToListAsync<Absence?>();
    }

    public Task RemoveAbsenceAsync(Absence absence)
    {
        _dbContext.Remove(absence);

        return Task.CompletedTask;
    }

    public Task RemoveAbsencesAsync(List<Absence> absences)
    {
        _dbContext.RemoveRange(absences);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Absence absence)
    {
        _dbContext.Update(absence);

        return Task.CompletedTask;
    }
}
