using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Features.WhatsApp;

public class WhatsappConfiguration : IEntityTypeConfiguration<WhatsappNotificationDataModel>
{
    public void Configure(EntityTypeBuilder<WhatsappNotificationDataModel> builder)
    {
        builder.ToTable("whatsapp_notification_data");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Template).IsRequired();
        builder.Property(e => e.Data).HasColumnType("jsonb");
        builder.Property(e => e.PhoneNumber).HasColumnType("jsonb");
        builder.Property(e => e.CreatedDateTime).HasColumnType("timestamp with time zone");
        builder.Property(e => e.ProcessedDateTime).HasColumnType("timestamp with time zone");
    }
}
