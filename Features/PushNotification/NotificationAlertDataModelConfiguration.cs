using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Features.PushNotification
{
    public class NotificationAlertDataModelConfiguration : IEntityTypeConfiguration<NotificationAlertDataModel>
    {
        public void Configure(EntityTypeBuilder<NotificationAlertDataModel> builder)
        {
            builder.ToTable("notification_alert_data");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.TimeStamp).HasColumnType("timestamp with time zone");
            builder.Property(e => e.ExpiryTimeStamp).HasColumnType("timestamp with time zone");
            builder.Property(e => e.AlertData).HasColumnType("jsonb");
            builder.Property(e => e.PushData).HasColumnType("jsonb");
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
        }
    }
}