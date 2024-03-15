using BookYourVisit.Domain.Salons;

namespace BookYourVisit.Application.Common.Interfaces;
public interface ISalonsRepository
{
    Task AddSalonAsync(Salon salon);
    Task UpdateAsync(Salon salon);
    Task<Salon?> GetByIdAsync(Guid id);
    Task<List<Salon?>> ListSalonsAsync(int page, int pageSize);
    Task<int> Count();
    Task RemoveReviewAsync(Salon salon);
}
