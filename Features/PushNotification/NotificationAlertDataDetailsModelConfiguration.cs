using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Features.PushNotification
{
    public class NotificationAlertDataDetailsModelConfiguration : IEntityTypeConfiguration<NotificationAlertDataDetailsModel>
    {
        public void Configure(EntityTypeBuilder<NotificationAlertDataDetailsModel> builder)
        {
            builder.ToTable("notification_alert_data_details");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ReadTimeStamp).HasColumnType("timestamp with time zone");
        }
    }
}