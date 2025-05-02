using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SubscriptionModelConfiguration : IEntityTypeConfiguration<SubscriptionModel>
    {
        public void Configure(EntityTypeBuilder<SubscriptionModel> builder)
        {
            builder.ToTable("subscription");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Code).HasMaxLength(5).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ImageUrl).HasMaxLength(200);
            builder.Property(e => e.Fee).HasDefaultValue(0).IsRequired();
            builder.Property(e => e.ReRegistrationFee).HasDefaultValue(0).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.IsAddon).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsPremium).IsRequired();
            builder.Property(e => e.DisplayName).HasColumnType("jsonb");
            builder.Property(e => e.DisplayDescription).HasColumnType("jsonb");
            builder.Property(e => e.IsSearchable).HasDefaultValue(false);
        }
    }
}