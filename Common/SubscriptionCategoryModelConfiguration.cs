using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SubscriptionCategoryModelConfiguration : IEntityTypeConfiguration<SubscriptionCategoryModel>
    {
        public void Configure(EntityTypeBuilder<SubscriptionCategoryModel> builder)
        {
            builder.ToTable("subscription_category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Code).HasMaxLength(50);
            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}