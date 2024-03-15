using BookYourVisit.Domain.Messages;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IMessagesRepository
{
    Task AddMessageAsync(Message message);
    Task<List<Message?>> ListByVisitIdAsync(Guid visitId);
    Task RemoveMessageAsync(Message message);
    Task RemoveMeesagesAsync(List<Message> message);
}
