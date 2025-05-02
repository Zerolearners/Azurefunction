using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ComplexionModelConfiguration : IEntityTypeConfiguration<ComplexionModel>
    {
        public void Configure(EntityTypeBuilder<ComplexionModel> builder)
        {
            builder.ToTable("complexion");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.DisplayName)
         .HasColumnType("jsonb");
            builder.Property(e => e.Code)
                .HasMaxLength(50);
            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}