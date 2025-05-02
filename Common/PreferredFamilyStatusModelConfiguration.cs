using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredFamilyStatusModelConfiguration : IEntityTypeConfiguration<PreferredFamilyStatusModel>
    {
        public void Configure(EntityTypeBuilder<PreferredFamilyStatusModel> builder)
        {
            builder.ToTable("prefered_family_status");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}