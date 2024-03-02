using BookYourVisit.Domain.Absences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookYourVisit.Infrastructure.Configurations;
public class AbsencesConfigurations : IEntityTypeConfiguration<Absence>
{
    public void Configure(EntityTypeBuilder<Absence> builder)
    {
        builder.ToTable("Absences");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Reason)
            .HasMaxLength(250);

    }
}
