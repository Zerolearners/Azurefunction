using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class LookupSettingModelConfiguration : IEntityTypeConfiguration<LookupSettingModel>
    {
        public void Configure(EntityTypeBuilder<LookupSettingModel> builder)
        {
            builder.ToTable("lookup_settings");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .HasMaxLength(200).IsRequired();
            builder.Property(e => e.Code)
                .HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        }
    }
}