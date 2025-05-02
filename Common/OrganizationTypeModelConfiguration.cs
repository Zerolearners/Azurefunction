using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class OrganizationTypeModelConfiguration : IEntityTypeConfiguration<OrganizationTypeModel>
    {
        public void Configure(EntityTypeBuilder<OrganizationTypeModel> builder)
        {
            builder.ToTable("organization_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Code).HasMaxLength(5);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.DisplayName).HasColumnType("jsonb");
        }
    }
}