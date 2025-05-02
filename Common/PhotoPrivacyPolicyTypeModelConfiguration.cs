using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PhotoPrivacyPolicyTypeModelConfiguration : IEntityTypeConfiguration<PhotoPrivacyPolicyTypeModel>
    {
        public void Configure(EntityTypeBuilder<PhotoPrivacyPolicyTypeModel> builder)
        {
            builder.ToTable("photo_privacy_policy_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Code).HasMaxLength(5).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        }
    }
}