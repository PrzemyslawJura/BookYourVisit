using BookYourVisit.Domain.Visits;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IVisitsRepository
{
    Task AddVisitAsync(Visit visit);
    Task UpdateAsync(Visit visit);
    Task<Visit?> GetByIdAsync(Guid id);
    Task<List<Visit?>> ListByServiceIdAsync(Guid serviceId);
    Task<List<Visit?>> ListByUserIdAsync(Guid userId);
    Task RemoveVisitAsync(Visit visit);
    Task RemoveVisitsAsync(List<Visit> visits);
}
