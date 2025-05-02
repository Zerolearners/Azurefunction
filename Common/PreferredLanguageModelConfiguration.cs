using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredLanguageModelConfiguration : IEntityTypeConfiguration<PreferredLanguageModel>
    {
        public void Configure(EntityTypeBuilder<PreferredLanguageModel> builder)
        {
            builder.ToTable("prefered_language");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}