using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class IncomeModelConfiguration : IEntityTypeConfiguration<IncomeModel>
    {
        public void Configure(EntityTypeBuilder<IncomeModel> builder)
        {
            builder.ToTable("income");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Code).HasMaxLength(50);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.DisplayName).HasColumnType("jsonb");
            builder.Property(e => e.IsLegacyItem).HasDefaultValue(false);
        }
    }
}