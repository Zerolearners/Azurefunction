using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredComplexionModelConfiguration : IEntityTypeConfiguration<PreferredComplexionModel>
    {
        public void Configure(EntityTypeBuilder<PreferredComplexionModel> builder)
        {
            builder.ToTable("prefered_complexion");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}