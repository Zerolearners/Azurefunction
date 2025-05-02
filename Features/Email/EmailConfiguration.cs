using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ai_finder_be_schedulers_donetcore.Features.Email;
public class EmailConfiguration : IEntityTypeConfiguration<EmailNotificationDataModel>
{
    public void Configure(EntityTypeBuilder<EmailNotificationDataModel> builder)
    {
        builder.ToTable("email_notification_data");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Template).IsRequired();
        builder.Property(e => e.Data).HasColumnType("jsonb");
        builder.Property(e => e.EmailId).HasMaxLength(50).IsRequired();
        builder.Property(e => e.CreatedDateTime).HasColumnType("timestamp with time zone");
        builder.Property(e => e.ProcessedDateTime).HasColumnType("timestamp with time zone");
    }
}
