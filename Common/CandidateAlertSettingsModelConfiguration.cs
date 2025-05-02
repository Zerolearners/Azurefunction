using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateAlertSettingsModelConfiguration : IEntityTypeConfiguration<CandidateAlertSettingsModel>
    {
        public void Configure(EntityTypeBuilder<CandidateAlertSettingsModel> builder)
        {
            builder.ToTable("candidate_alert_settings");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.IsEmail).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsSms).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsWhatsapp).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsPushNotification).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsSound).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.AuditProperty).HasColumnType("jsonb");
        }

    }
}