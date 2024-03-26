using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Salons;
using BookYourVisit.Infrastructure.Common.Persistence;

namespace BookYourVisit.Infrastructure.Repositories;
public class AddressesRepository : IAddressesRepository
{
    private readonly BookYourVisitDbContext _dbContext;

    public AddressesRepository(BookYourVisitDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAddressAsync(Address address)
    {
        await _dbContext.Addresses.AddAsync(address);
    }

    public async Task<Address?> GetBySalonIdAsync(Guid salonId)
    {
        return await _dbContext.Addresses.FindAsync(salonId);
    }

    public Task RemoveAddressAsync(Address address)
    {
        _dbContext.Remove(address);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Address address)
    {
        _dbContext.Update(address);

        return Task.CompletedTask;
    }
}
