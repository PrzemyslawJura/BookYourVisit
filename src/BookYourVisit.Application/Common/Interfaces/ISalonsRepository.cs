using BookYourVisit.Domain.Salons;

namespace BookYourVisit.Application.Common.Interfaces;
public interface ISalonsRepository
{
    Task AddSalonAsync(Salon salon);
    Task UpdateAsync(Salon salon);
    Task<Salon?> GetByIdAsync(Guid id);
    Task RemoveReviewAsync(Salon salon);
}
