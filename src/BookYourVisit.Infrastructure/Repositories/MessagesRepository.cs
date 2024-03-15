using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Messages;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Infrastructure.Repositories;
public class MessagesRepository : IMessagesRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public MessagesRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddMessageAsync(Message message)
    {
        await _dbContext.Messages.AddAsync(message);
    }

    public async Task<List<Message?>> ListByVisitIdAsync(Guid visitId)
    {
        return await _dbContext.Messages
            .AsNoTracking()
            .Where(message => message.VisitId == visitId)
            .ToListAsync<Message?>();
    }

    public Task RemoveMeesagesAsync(List<Message> message)
    {
        _dbContext.Remove(message);

        return Task.CompletedTask;
    }

    public Task RemoveMessageAsync(Message message)
    {
        _dbContext.Update(message);

        return Task.CompletedTask;
    }
}
