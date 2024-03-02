namespace BookYourVisit.Domain.Messages;
public class Message
{
    public Guid Id { get; private set; }
    public UserType UserType { get; private set; }
    public string Content { get; private set; } = null!;
    public DateTime Data { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid VisitId { get; private set; }

    public Message(
        UserType userType,
        string content,
        DateTime data,
        Guid visitId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        UserType = userType;
        Content = content;
        Data = data;
        VisitId = visitId;
    }
    private Message()
    {
    }
}
