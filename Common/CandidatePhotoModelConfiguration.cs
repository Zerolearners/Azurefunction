using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidatePhotoModelConfiguration : IEntityTypeConfiguration<CandidatePhotoModel>
    {
        public void Configure(EntityTypeBuilder<CandidatePhotoModel> builder)
        {
            builder.ToTable("candidate_photo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.SourceFileUrl).IsRequired();
            builder.Property(e => e.Order).IsRequired();
            builder.Property(e => e.IsVisible).HasDefaultValue(true);
            builder.Property(e => e.PhotoPassword).HasMaxLength(20);
            builder.Property(e => e.AuditProperty).HasColumnType("jsonb");
            builder.Property(e => e.MigrationTableName).HasMaxLength(30);
            builder.Property(e => e.IsArchived).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.TimeStamp).HasColumnType("timestamp with time zone");
        }
    }
}