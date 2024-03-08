using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Reviews;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class ReviewsRepository : IReviewsRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public ReviewsRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddReviewAsync(Review review)
    {
        await _dbContext.Reviews.AddAsync(review);
    }

    public async Task<List<Review?>> ListBySalonIdAsync(Guid salonId)
    {
        return await _dbContext.Reviews
            .AsNoTracking()
            .Where(review => review.SalonId == salonId)
            .ToListAsync<Review?>();
    }

    public async Task<List<Review?>> ListByUserIdAsync(Guid userId)
    {
        return await _dbContext.Reviews
            .AsNoTracking()
            .Where(review => review.UserId == userId)
            .ToListAsync<Review?>();
    }

    public Task RemoveReviewAsync(Review review)
    {
        _dbContext.Remove(review);

        return Task.CompletedTask;
    }

    public Task RemoveReviewsAsync(List<Review> review)
    {
        _dbContext.RemoveRange(review);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Review review)
    {
        _dbContext.Update(review);

        return Task.CompletedTask;
    }
}
