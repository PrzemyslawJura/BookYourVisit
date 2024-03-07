using BookYourVisit.Domain.WorkingSlots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookYourVisit.Infrastructure.Configurations;
public class WorkingSlotsConfigurations : IEntityTypeConfiguration<WorkingSlot>
{
    public void Configure(EntityTypeBuilder<WorkingSlot> builder)
    {
        builder.ToTable("WorkingSlots");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.DayOfWeek)
            .HasConversion<string>();

        builder.HasOne(x => x.Salon)
            .WithMany(x => x.WorkingSlots)
            .HasForeignKey(x => x.SalonId)
            .IsRequired();
    }
}
