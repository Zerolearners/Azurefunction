using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class BloodGroupModelConfiguration : IEntityTypeConfiguration<BloodGroupModel>
    {
        public void Configure(EntityTypeBuilder<BloodGroupModel> builder)
        {
            builder.ToTable("blood_group");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.Name)
                .HasMaxLength(5).IsRequired();
            builder.Property(e => e.Code)
                .HasMaxLength(5);
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.DisplayName)
                .HasColumnType("jsonb");
        }
    }
}