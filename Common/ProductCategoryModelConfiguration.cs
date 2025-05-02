using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ProductCategoryModelConfiguration : IEntityTypeConfiguration<ProductCategoryModel>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryModel> builder)
        {
            builder.ToTable("product_category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Code).HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
        }
    }
}