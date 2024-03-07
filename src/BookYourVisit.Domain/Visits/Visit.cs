using BookYourVisit.Domain.Messages;
using BookYourVisit.Domain.Services;
using BookYourVisit.Domain.Users;
using ErrorOr;
using Throw;

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
    public Guid UserId { get; private set; }

    public IEnumerable<Message> Messages { get; private set; }
    public Service Service { get; private set; }
    public User User { get; private set; }

    public Visit(
        DateTime dateFrom,
        DateTime dateTo,
        VisitStatus status,
        Guid serviceId,
        Guid userId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        DateFrom = dateFrom;
        DateTo = dateTo;
        Status = status;
        ServiceId = serviceId;
        UserId = userId;
    }
    private Visit()
    {
    }
    public ErrorOr<Success> AddMessage(Message message)
    {
        _messageIds.Throw().IfContains(message.Id);

        _messageIds.Add(message.Id);

        return Result.Success;
    }
    public bool HasMessage(Guid messageId)
    {
        return _messageIds.Contains(messageId);
    }
    public void RemoveMessage(Guid messageId)
    {
        _messageIds.Throw().IfNotContains(messageId);

        _messageIds.Remove(messageId);
    }
}
