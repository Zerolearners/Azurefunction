using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredReligionModelConfiguration : IEntityTypeConfiguration<PreferredReligionModel>
    {
        public void Configure(EntityTypeBuilder<PreferredReligionModel> builder)
        {
            builder.ToTable("prefered_religion");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.ReligionTreePath).IsRequired();
        }
    }
}