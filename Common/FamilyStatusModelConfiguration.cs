using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class FamilyStatusModelConfiguration : IEntityTypeConfiguration<FamilyStatusModel>
    {
        public void Configure(EntityTypeBuilder<FamilyStatusModel> builder)
        {
            builder.ToTable("family_status");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.Name)
                .HasMaxLength(250);
            builder.Property(e => e.DisplayName)
          .HasColumnType("jsonb");
            builder.Property(e => e.Code)
                .HasMaxLength(5);
            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}