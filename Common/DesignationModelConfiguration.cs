using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class DesignationModelConfiguration : IEntityTypeConfiguration<DesignationModel>
    {
        public void Configure(EntityTypeBuilder<DesignationModel> builder)
        {
            builder.ToTable("designation");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasColumnType("jsonb");
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
        }
    }
}