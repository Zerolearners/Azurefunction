using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Features.Sms;
public class SmsConfiguration : IEntityTypeConfiguration<SmsNotificationDataModel>
{
    public void Configure(EntityTypeBuilder<SmsNotificationDataModel> builder)
    {
        builder.ToTable("sms_notification_data");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Template).HasColumnType("jsonb");
        builder.Property(e => e.Data).HasColumnType("jsonb");
        builder.Property(e => e.PhoneNumber).HasColumnType("jsonb");
        builder.Property(e => e.CreatedDateTime).HasColumnType("timestamp with time zone");
        builder.Property(e => e.ProcessedDateTime).HasColumnType("timestamp with time zone");
    }
}
