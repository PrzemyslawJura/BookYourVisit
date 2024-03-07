using BookYourVisit.Domain.Salons;
using BookYourVisit.Domain.Users;

namespace BookYourVisit.Domain.Reviews;
public class Review
{
    public Guid Id { get; private set; }
    public Rating Rating { get; private set; }
    public string Description { get; private set; } = null!;
    public bool IsDelete { get; private set; } = false;
    public Guid SalonId { get; private set; }
    public Guid UserId { get; private set; }

    public User User { get; private set; }
    public Salon Salon { get; private set; }

    public Review(
        Rating rating,
        string description,
        Guid salonId,
        Guid userId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Rating = rating;
        Description = description;
        SalonId = salonId;
        UserId = userId;
    }
    private Review()
    {
    }
}
