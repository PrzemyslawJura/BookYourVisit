using BookYourVisit.Domain.Reviews;
using BookYourVisit.Domain.Workers;
using BookYourVisit.Domain.WorkingSlots;
using ErrorOr;
using Throw;

namespace BookYourVisit.Domain.Salons;
public class Salon
{
    public List<Guid> _reviewIds = new();
    public List<Guid> _workerIds = new();
    public List<Guid> _workingSlotIds = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string MainPhoto { get; private set; } = null!;
    public string Photos { get; private set; } = null!;
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; } = null!;
    public float Latitude { get; private set; }
    public float Longitude { get; private set; }
    public bool IsDelete { get; private set; } = false;

    public Address Address { get; private set; }
    public IEnumerable<Review> Reviews { get; private set; }
    public IEnumerable<Worker> Workers { get; private set; }
    public IEnumerable<WorkingSlot> WorkingSlots { get; private set; }

    public Salon(
        string name,
        string description,
        string mainPhoto,
        string photos,
        string phoneNumber,
        string email,
        float latitude,
        float longitute,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        MainPhoto = mainPhoto;
        Photos = photos;
        PhoneNumber = phoneNumber;
        Email = email;
        Latitude = latitude;
        Longitude = longitute;
    }
    private Salon()
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
    public ErrorOr<Success> AddWorker(Worker worker)
    {
        _workerIds.Throw().IfContains(worker.Id);

        _workerIds.Add(worker.Id);

        return Result.Success;
    }
    public bool HasWorker(Guid workerId)
    {
        return _workerIds.Contains(workerId);
    }
    public void RemoveWorker(Guid workerId)
    {
        _workerIds.Throw().IfNotContains(workerId);

        _workerIds.Remove(workerId);
    }
    public ErrorOr<Success> AddWorkingSlot(WorkingSlot workingSlot)
    {
        _workingSlotIds.Throw().IfContains(workingSlot.Id);

        _workingSlotIds.Add(workingSlot.Id);

        return Result.Success;
    }
    public bool HasWorkingSlot(Guid workingSlotId)
    {
        return _workingSlotIds.Contains(workingSlotId);
    }
    public void RemoveWorkingSlot(Guid workingSlotId)
    {
        _workingSlotIds.Throw().IfNotContains(workingSlotId);

        _workingSlotIds.Remove(workingSlotId);
    }
}
