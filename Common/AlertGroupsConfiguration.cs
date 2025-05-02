using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common;

public class AlertGroupsConfiguration : IEntityTypeConfiguration<AlertGroupsModel>
{
    public void Configure(EntityTypeBuilder<AlertGroupsModel> builder)
    {
        builder.ToTable("alert_groups");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.IsDisplayInEmail).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.IsDisplayInSms).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.IsDisplayInWhatsapp).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.IsDisplayInPushNotification).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();
        builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.Code).IsRequired();
        builder.Property(e => e.Name).HasColumnType("jsonb");
    }
}
