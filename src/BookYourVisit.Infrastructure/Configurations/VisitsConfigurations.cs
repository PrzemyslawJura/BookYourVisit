using BookYourVisit.Domain.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookYourVisit.Infrastructure.Configurations;
public class VisitsConfigurations : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable("Visits");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.DateFrom)
            .HasColumnType("smalldatetime");

        builder.Property(x => x.DateTo)
            .HasColumnType("smalldatetime");

        builder.Property(x => x.Status)
            .HasConversion<string>();

        builder.HasOne(x => x.Service)
            .WithMany(x => x.Visits)
            .HasForeignKey(x => x.ServiceId)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Visits)
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}
