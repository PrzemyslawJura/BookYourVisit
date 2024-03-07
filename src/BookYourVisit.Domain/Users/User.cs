using BookYourVisit.Domain.Reviews;
using BookYourVisit.Domain.Visits;
using ErrorOr;
using Throw;

namespace BookYourVisit.Domain.Users;
public class User
{
    public List<Guid> _reviewIds = new();
    public List<Guid> _visitIds = new();

    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string SecondName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PhoneNumber { get; private set; }
    public bool IsDelete { get; private set; } = false;

    public IEnumerable<Review> Reviews { get; private set; }
    public IEnumerable<Visit> Visits { get; private set; }

    public User(
        string firstName,
        string secondName,
        string email,
        string phoneNumber,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        FirstName = firstName;
        SecondName = secondName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
    private User()
    {
    }
    public ErrorOr<Success> AddReview(Review review)
    {
        _reviewIds.Throw().IfContains(review.Id);

        _reviewIds.Add(review.Id);

        return Result.Success;
    }
    public bool HasReview(Guid reviewId)
    {
        return _reviewIds.Contains(reviewId);
    }
    public void RemoveReview(Guid reviewId)
    {
        _reviewIds.Throw().IfNotContains(reviewId);

        _reviewIds.Remove(reviewId);
    }
    public ErrorOr<Success> AddVisit(Visit visit)
    {
        _visitIds.Throw().IfContains(visit.Id);

        _visitIds.Add(visit.Id);

        return Result.Success;
    }
    public bool HasVisit(Guid visitId)
    {
        return _visitIds.Contains(visitId);
    }
    public void RemoveVisit(Guid visitId)
    {
        _visitIds.Throw().IfNotContains(visitId);

        _visitIds.Remove(visitId);
    }
}
