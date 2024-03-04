using BookYourVisit.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookYourVisit.Infrastructure.Configurations;
public class MessagesConfigurations : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.UserType)
            .HasConversion<string>();

        builder.Property(x => x.Content)
            .HasMaxLength(250);

        builder.Property(x => x.Date)
            .HasColumnType("smalldatetime");

        builder.HasOne(x => x.Visit)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.VisitId)
            .IsRequired();
    }
}
