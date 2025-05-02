using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SourceCategoryModelConfiguration : IEntityTypeConfiguration<SourceCategoryModel>
    {
        public void Configure(EntityTypeBuilder<SourceCategoryModel> builder)
        {
            builder.ToTable("source_category");
            builder.HasKey("Id");
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.DisplayName).HasColumnType("jsonb");
            builder.Property(e => e.Code).HasMaxLength(5);
            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}