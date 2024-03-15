using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.WorkingSlots;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class WorkingSlotsRepository : IWorkingSlotsRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public WorkingSlotsRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddWorkingSlotAsync(WorkingSlot workingSlot)
    {
        await _dbContext.WorkingSlots.AddAsync(workingSlot);
    }

    public async Task<WorkingSlot?> GetByIdAsync(Guid id)
    {
        return await _dbContext.WorkingSlots.FirstOrDefaultAsync(workingSlot => workingSlot.Id == id);
    }

    public async Task<List<WorkingSlot?>> ListBySalonIdAsync(Guid salonId)
    {
        return await _dbContext.WorkingSlots
            .AsNoTracking()
            .Where(workingSlot => workingSlot.SalonId == salonId)
            .ToListAsync<WorkingSlot?>();
    }

    public Task RemoveWorkingSlotAsync(WorkingSlot workingSlot)
    {
        _dbContext.Remove(workingSlot);

        return Task.CompletedTask;
    }

    public Task RemoveWorkingSlotsAsync(List<WorkingSlot> workingSlots)
    {
        _dbContext.RemoveRange(workingSlots);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(WorkingSlot workingSlot)
    {
        _dbContext.Update(workingSlot);

        return Task.CompletedTask;
    }
}
