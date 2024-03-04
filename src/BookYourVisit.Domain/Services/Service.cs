using BookYourVisit.Domain.Visits;
using BookYourVisit.Domain.Workers;

namespace BookYourVisit.Domain.Services;
public class Service
{
    public List<Guid> _visitIds = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public float Price { get; private set; }
    public int Time { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid WorkerId { get; private set; }

    public Worker Worker { get; private set; }
    public IEnumerable<Visit> Visits { get; private set; }

    public Service(
        string name,
        string description,
        float price,
        int time,
        Guid workerId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Time = time;
        WorkerId = workerId;
    }
    private Service()
    {
    }
}
