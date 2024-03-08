using BookYourVisit.Domain.Reviews;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IReviewsRepository
{
    Task AddReviewAsync(Review review);
    Task UpdateAsync(Review review);
    Task<List<Review?>> ListBySalonIdAsync(Guid salonId);
    Task<List<Review?>> ListByUserIdAsync(Guid userId);
    Task RemoveReviewAsync(Review review);
    Task RemoveReviewsAsync(List<Review> review);
}
