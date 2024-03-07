using BookYourVisit.Domain.Salons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookYourVisit.Infrastructure.Configurations;
public class AddressesConfigurations : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Country)
            .HasMaxLength(50);

        builder.Property(x => x.City)
            .HasMaxLength(50);

        builder.Property(x => x.Street)
            .HasMaxLength(50);

        builder.Property(x => x.StreetNumber)
            .HasMaxLength(20);

        builder.Property(x => x.PostalCode)
            .HasMaxLength(20);

        builder.HasOne(x => x.Salon)
            .WithOne(x => x.Address)
            .HasForeignKey<Address>(x => x.SalonId)
            .IsRequired();
    }
}
