using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class NotificationConfiguration : IEntityTypeConfiguration<NotificationCategoryModel>
    {
        public void Configure(EntityTypeBuilder<NotificationCategoryModel> builder)
        {
            builder.ToTable("notification_category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.SmsTemplate).HasColumnType("jsonb");
            builder.Property(e => e.WhatsappTemplateUrl).HasMaxLength(100);
            builder.Property(e => e.EmailTemplateUrl).HasMaxLength(100);
            builder.Property(e => e.PushNotificationTemplate).HasColumnType("jsonb");
            builder.Property(e => e.IsSms).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsEmail).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsWhatsapp).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsPushNotification).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.Code).IsRequired();
        }
    }
}