using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class InterestMessageModelConfiguration : IEntityTypeConfiguration<InterestMessageModel>
    {
        public void Configure(EntityTypeBuilder<InterestMessageModel> builder)
        {
            builder.ToTable("candidate_message");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CustomMessage).HasMaxLength(2000);
            builder.Property(e => e.IsReaded).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsSenderStarred).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsReceiverStarred).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsSenderTrashed).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsReceiverTrashed).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.GroupCode).HasMaxLength(50);
            builder.Property(e => e.AuditProperty).HasColumnType("jsonb");
            builder.Property(e => e.TimeStamp).HasColumnType("timestamp with time zone");
            builder.Property(e => e.IsWithdraw).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsSenderDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsReceiverDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsRespondLater).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsAdminSenderDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsAdminReceiverDeleted).HasDefaultValue(false).IsRequired();
            builder.HasIndex(e => e.MigrationId);
            builder.HasIndex(e => e.GroupCode);
        }
    }
}