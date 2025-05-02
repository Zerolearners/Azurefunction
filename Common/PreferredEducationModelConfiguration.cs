using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredEducationModelConfiguration : IEntityTypeConfiguration<PreferredEducationModel>
    {
        public void Configure(EntityTypeBuilder<PreferredEducationModel> builder)
        {
            builder.ToTable("prefered_education");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}