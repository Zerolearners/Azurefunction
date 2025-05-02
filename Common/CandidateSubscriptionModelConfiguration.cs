using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateSubscriptionModelConfiguration : IEntityTypeConfiguration<CandidateSubscriptionModel>
    {
        public void Configure(EntityTypeBuilder<CandidateSubscriptionModel> builder)
        {
            builder.ToTable("candidate_subscription");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.IsSubscriptionActive).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.StartTimeStamp).HasColumnType("timestamp with time zone");
            builder.Property(e => e.EndTimeStamp).HasColumnType("timestamp with time zone");
            builder.Property(e => e.LastMessageSentTimeStamp).HasColumnType("timestamp with time zone");
            builder.Property(e => e.LastContactViewTimestamp).HasColumnType("timestamp with time zone");
        }
    }
}