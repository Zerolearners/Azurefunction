using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ConfidentialFilterModelConfiguration : IEntityTypeConfiguration<ConfidentialFilterModel>
    {
        public void Configure(EntityTypeBuilder<ConfidentialFilterModel> builder)
        {
            builder.ToTable("confidential_filter");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}