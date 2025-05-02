using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredSpecialNeedsModelConfiguration : IEntityTypeConfiguration<PreferredSpecialNeedsModel>
    {
        public void Configure(EntityTypeBuilder<PreferredSpecialNeedsModel> builder)
        {
            builder.ToTable("prefered_special_needs");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}