using BookYourVisit.Domain.WorkingSlots;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IWorkingSlotsRepository
{
    Task AddWorkingSlotAsync(WorkingSlot workingSlot);
    Task UpdateAsync(WorkingSlot workingSlot);
    Task<WorkingSlot?> GetByIdAsync(Guid id);
    Task<List<WorkingSlot?>> ListBySalonIdAsync(Guid salonId);
    Task RemoveWorkingSlotAsync(WorkingSlot workingSlot);
    Task RemoveWorkingSlotsAsync(List<WorkingSlot> workingSlots);
}
