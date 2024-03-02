namespace BookYourVisit.Domain.Visits;
public class Visit
{
    public List<Guid> _messageIds = new();

    public Guid Id { get; private set; }
    public DateTime DateFrom { get; private set; }
    public DateTime DateTo { get; private set; }
    public VisitStatus Status { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid ServiceId { get; private set; }
    public Guid WorkerId { get; private set; }
    public Guid UserId { get; private set; }

    public Visit(
        DateTime dateFrom,
        DateTime dateTo,
        VisitStatus status,
        Guid serviceId,
        Guid workerId,
        Guid userId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        DateFrom = dateFrom;
        DateTo = dateTo;
        Status = status;
        ServiceId = serviceId;
        WorkerId = workerId;
        UserId = userId;
    }
    private Visit()
    {
    }
}
