using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class MessageStatusModelConfiguration : IEntityTypeConfiguration<MessageStatusModel>
    {
        public void Configure(EntityTypeBuilder<MessageStatusModel> builder)
        {
            builder.ToTable("message_status");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Code).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.IsFilterData).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.Colour).HasMaxLength(50);
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
        }
    }
}