namespace BookYourVisit.Domain.Absences;
public class Absence
{
    public Guid Id { get; private set; }
    public string Reason { get; private set; } = null!;
    public DateTime DataFrom { get; private set; }
    public DateTime DataTo { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid WorkerId { get; private set; }

    public Absence(
        string reason,
        DateTime dataFrom,
        DateTime dataTo,
        Guid workerId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Reason = reason;
        DataFrom = dataFrom;
        DataTo = dataTo;
        WorkerId = workerId;
    }
}
