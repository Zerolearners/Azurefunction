using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SpecialNeedsModelConfiguration : IEntityTypeConfiguration<SpecialNeedsModel>
    {
        public void Configure(EntityTypeBuilder<SpecialNeedsModel> builder)
        {
            builder.ToTable("special_needs");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Name)
                .HasMaxLength(100).IsRequired();
            builder.Property(e => e.DisplayName)
         .HasColumnType("jsonb");
            builder.Property(e => e.Code)
                .HasMaxLength(50);
            builder.Property(e => e.IsVerified)
                .IsRequired();
            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}