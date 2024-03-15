using BookYourVisit.Domain.Users;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IUsersRepository
{
    Task AddUserAsync(User user);
    Task UpdateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task RemoveUserAsync(User user);
    Task RemoveUsersAsync(List<User> users);
}
