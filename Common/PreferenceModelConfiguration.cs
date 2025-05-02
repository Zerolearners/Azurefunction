using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferenceModelConfiguration : IEntityTypeConfiguration<PreferenceModel>
    {
        public void Configure(EntityTypeBuilder<PreferenceModel> builder)
        {
            builder.ToTable("preference");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.PartnerExpectation).HasMaxLength(6000);
            builder.Property(e => e.PartnerEducation).HasMaxLength(6000);
            builder.Property(e => e.PartnerProfesssion).HasMaxLength(6000);
        }
    }
}