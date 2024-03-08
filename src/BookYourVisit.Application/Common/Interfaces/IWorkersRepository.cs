using BookYourVisit.Domain.Workers;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IWorkersRepository
{
    Task AddWorkerAsync(Worker worker);
    Task UpdateAsync(Worker worker);
    Task<Worker?> GetByIdAsync(Guid id);
    Task<List<Worker?>> ListBySalonIdAsync(Guid salonId);
    Task RemoveWorkerAsync(Worker worker);
    Task RemoveWorkersAsync(List<Worker> worker);
}
