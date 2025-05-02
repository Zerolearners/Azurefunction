using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ResidentTypeModelConfiguration : IEntityTypeConfiguration<ResidentTypeModel>
    {
        public void Configure(EntityTypeBuilder<ResidentTypeModel> builder)
        {
            builder.ToTable("resident_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.Code)
                .HasMaxLength(5);
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.DisplayName)
                .HasColumnType("jsonb");
        }
    }
}