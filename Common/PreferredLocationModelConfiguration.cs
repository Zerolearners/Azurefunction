using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredLocationModelConfiguration : IEntityTypeConfiguration<PreferredLocationModel>
    {
        public void Configure(EntityTypeBuilder<PreferredLocationModel> builder)
        {
            builder.ToTable("prefered_location");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}