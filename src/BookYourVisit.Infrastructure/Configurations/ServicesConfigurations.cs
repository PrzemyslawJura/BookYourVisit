using BookYourVisit.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookYourVisit.Infrastructure.Configurations;
public class ServicesConfigurations : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
           .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(250);

        builder.Property(x => x.Currency)
            .HasMaxLength(3);

        builder.Property(x => x.Time)
            .HasMaxLength(4);

        builder.HasOne(x => x.Worker)
            .WithMany(x => x.Services)
            .HasForeignKey(x => x.WorkerId)
            .IsRequired();
    }
}
