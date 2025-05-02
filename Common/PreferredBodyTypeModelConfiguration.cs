using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredBodyTypeModelConfiguration : IEntityTypeConfiguration<PreferredBodyTypeModel>
    {
        public void Configure(EntityTypeBuilder<PreferredBodyTypeModel> builder)
        {
            builder.ToTable("prefered_body_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}