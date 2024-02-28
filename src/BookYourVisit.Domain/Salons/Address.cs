using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourVisit.Domain.Salons;
public class Address
{
    public Guid Id { get; private set; }
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string StreetNumber { get; private set; } = null!;
    public string PostalCode { get; private set; }
    public Guid SalonId { get; private set; }

    public Address(
        string country,
        string city,
        string street,
        string streetNumber,
        string postalCode,
        Guid salonId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Country = country;
        City = city;
        Street = street;
        StreetNumber = streetNumber;
        PostalCode = postalCode;
        SalonId = salonId;
    }
}
