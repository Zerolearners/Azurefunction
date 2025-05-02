using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateEducationModelConfiguration : IEntityTypeConfiguration<CandidateEducationModel>
    {
        public void Configure(EntityTypeBuilder<CandidateEducationModel> builder)
        {
            builder.ToTable("candidate_education");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Priority).IsRequired();
        }
    }
}