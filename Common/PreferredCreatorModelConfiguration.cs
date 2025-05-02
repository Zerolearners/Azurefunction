using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredCreatorModelConfiguration : IEntityTypeConfiguration<PreferredCreatorModel>
    {
        public void Configure(EntityTypeBuilder<PreferredCreatorModel> builder)
        {
            builder.ToTable("prefered_creator");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}