using BookYourVisit.Domain.Salons;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IAddressesRepository
{
    Task AddAddressAsync(Address absence);
    Task UpdateAsync(Address absence);
    Task<Address?> GetBySalonIdAsync(Guid SalonId);
    Task RemoveAddressAsync(Address absence);
}
