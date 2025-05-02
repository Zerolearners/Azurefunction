using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredProfessionModelConfiguration : IEntityTypeConfiguration<PreferredProfessionModel>
    {
        public void Configure(EntityTypeBuilder<PreferredProfessionModel> builder)
        {
            builder.ToTable("prefered_profession");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}