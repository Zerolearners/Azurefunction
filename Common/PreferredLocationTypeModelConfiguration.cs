using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredLocationTypeModelConfiguration : IEntityTypeConfiguration<PreferredLocationTypeModel>
    {
        public void Configure(EntityTypeBuilder<PreferredLocationTypeModel> builder)
        {
            builder.ToTable("prefered_location_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Code).HasMaxLength(50);
        }
    }
}