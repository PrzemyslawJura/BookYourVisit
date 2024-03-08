using BookYourVisit.Domain.Services;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IServicesRepository
{
    Task AddServiceAsync(Service service);
    Task UpdateAsync(Service service);
    Task<List<Service?>> ListByWorkerIdAsync(Guid workerId);
    Task<Service?> GetByIdAsync(Guid id);
    Task RemoveServiceAsync(Service service);
}
