using BookYourVisit.Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookYourVisit.Infrastructure.Configurations;
public class ReviewsConfigurations : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Rating)
            .HasConversion<int>();

        builder.Property(x => x.Description)
            .HasMaxLength(250);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.HasOne(x => x.Salon)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.SalonId)
            .IsRequired();
    }
}
