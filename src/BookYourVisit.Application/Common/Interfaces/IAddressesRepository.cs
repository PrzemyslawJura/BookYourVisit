using BookYourVisit.Domain.Salons;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IAddressesRepository
{
    Task AddAddressAsync(Address address);
    Task UpdateAsync(Address address);
    Task<Address?> GetBySalonIdAsync(Guid salonId);
    Task RemoveAddressAsync(Address address);
}
