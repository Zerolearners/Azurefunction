using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class LanguageModelConfiguration : IEntityTypeConfiguration<LanguageModel>
    {
        public void Configure(EntityTypeBuilder<LanguageModel> builder)
        {
            builder.ToTable("language");
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
            builder.Property(e => e.DisplayName).HasColumnType("jsonb");
        }
    }
}