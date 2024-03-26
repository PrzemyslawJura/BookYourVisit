using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Users;
using BookYourVisit.Infrastructure.Common.Persistence;

namespace BookYourVisit.Infrastructure.Repositories;
public class UsersRepository : IUsersRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public UsersRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public Task RemoveUserAsync(User user)
    {
        _dbContext.Remove(user);

        return Task.CompletedTask;
    }

    public Task RemoveUsersAsync(List<User> users)
    {
        _dbContext.RemoveRange(users);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(User user)
    {
        _dbContext.Update(user);

        return Task.CompletedTask;
    }
}
