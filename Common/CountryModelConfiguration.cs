using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CountryModelConfiguration : IEntityTypeConfiguration<CountryModel>
    {
        public void Configure(EntityTypeBuilder<CountryModel> builder)
        {
            builder.ToTable("country");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.Name)
                .HasMaxLength(250).IsRequired();
            builder.Property(e => e.DisplayName)
                .HasColumnType("jsonb");
            builder.Property(e => e.Code)
                .HasMaxLength(50);
            builder.Property(e => e.ISOCode)
                .HasMaxLength(2);
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.IsChildRelation)
                .HasDefaultValue<bool>(false);
            builder.Property(e => e.IsFrequentlyUsed)
                .HasDefaultValue<bool>(false);
        }
    }
}