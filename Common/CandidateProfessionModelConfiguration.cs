using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateProfessionModelConfiguration : IEntityTypeConfiguration<CandidateProfessionModel>
    {
        public void Configure(EntityTypeBuilder<CandidateProfessionModel> builder)
        {
            builder.ToTable("candidate_profession");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Details).HasMaxLength(300);
            builder.Property(e => e.Organization).HasMaxLength(200);
        }
    }
}