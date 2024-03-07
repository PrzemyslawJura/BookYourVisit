using BookYourVisit.Domain.Visits;
using BookYourVisit.Domain.Workers;
using ErrorOr;
using Throw;

namespace BookYourVisit.Domain.Services;
public class Service
{
    public List<Guid> _visitIds = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public float Price { get; private set; }
    public string Currency {  get; private set; }
    public int Time { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid WorkerId { get; private set; }

    public Worker Worker { get; private set; }
    public IEnumerable<Visit> Visits { get; private set; }

    public Service(
        string name,
        string description,
        float price,
        string currency,
        int time,
        Guid workerId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Currency = currency;
        Time = time;
        WorkerId = workerId;
    }
    private Service()
    {
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
