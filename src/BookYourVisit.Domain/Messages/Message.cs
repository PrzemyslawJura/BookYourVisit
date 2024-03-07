using BookYourVisit.Domain.Visits;

namespace BookYourVisit.Domain.Messages;
public class Message
{
    public Guid Id { get; private set; }
    public UserType UserType { get; private set; }
    public string Content { get; private set; } = null!;
    public DateTime Date { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid VisitId { get; private set; }

    public Visit Visit { get; private set; }

    public Message(
        UserType userType,
        string content,
        DateTime date,
        Guid visitId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        UserType = userType;
        Content = content;
        Date = date;
        VisitId = visitId;
    }
    private Message()
    {
    }
}
