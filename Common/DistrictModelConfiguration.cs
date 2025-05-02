using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class DistrictModelConfiguration : IEntityTypeConfiguration<DistrictModel>
    {
        public void Configure(EntityTypeBuilder<DistrictModel> builder)
        {
            builder.ToTable("district");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Name)
                .HasMaxLength(250).IsRequired();
            builder.Property(e => e.DisplayName)
                .HasColumnType("jsonb");
            builder.Property(e => e.Code)
                .HasMaxLength(50);
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.IsChildRelation)
                .HasDefaultValue<bool>(false);
        }
    }
}