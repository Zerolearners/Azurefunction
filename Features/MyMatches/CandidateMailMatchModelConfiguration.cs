using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Features.MyMatches
{
    public class CandidateMailMatchModelConfiguration : IEntityTypeConfiguration<CandidateMailMatchModel>
    {
        public void Configure(EntityTypeBuilder<CandidateMailMatchModel> builder)
        {
            builder.ToTable("candidate_mail_match");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.MatchSentTimestamp).HasColumnType("timestamp with time zone");
            builder.Property(e => e.MatchCandidates).IsRequired();
        }
    }
}