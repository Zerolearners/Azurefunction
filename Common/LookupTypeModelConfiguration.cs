using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class LookupTypeModelConfiguration : IEntityTypeConfiguration<LookupTypeModel>
    {
        public void Configure(EntityTypeBuilder<LookupTypeModel> builder)
        {
            builder.ToTable("lookup_type");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.Code)
                .HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        }
    }
}