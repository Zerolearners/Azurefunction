using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredOrganizatioTypeModelConfiguration : IEntityTypeConfiguration<PreferredOrganizationTypeModel>
    {
        public void Configure(EntityTypeBuilder<PreferredOrganizationTypeModel> builder)
        {
            builder.ToTable("prefered_organization_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}