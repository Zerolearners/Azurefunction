using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SourceModelConfiguration : IEntityTypeConfiguration<SourceModel>
    {
        public void Configure(EntityTypeBuilder<SourceModel> builder)
        {
            builder.ToTable("source");
            builder.HasKey("Id");
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(250).IsRequired();
            builder.Property(e => e.DisplayName).HasColumnType("jsonb");
            builder.Property(e => e.Code).HasMaxLength(5);
            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}