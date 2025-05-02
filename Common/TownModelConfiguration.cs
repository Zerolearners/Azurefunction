using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class TownModelConfiguration : IEntityTypeConfiguration<TownModel>
    {
        public void Configure(EntityTypeBuilder<TownModel> builder)
        {
            builder.ToTable("town");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Code).HasMaxLength(50);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.DisplayName).HasColumnType("jsonb");
        }
    }
}