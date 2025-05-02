using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateModelConfiguration : IEntityTypeConfiguration<CandidateModel>
    {
        public void Configure(EntityTypeBuilder<CandidateModel> builder)
        {
            builder.ToTable("candidate");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.CreatedContact);
            builder.Property(e => e.Id)
              .ValueGeneratedOnAdd();
            builder.Property(e => e.DOB)
               .HasColumnType("date");
            builder.Property(e => e.Name)
              .HasMaxLength(50);
            builder.Property(e => e.OtherReligion)
              .HasMaxLength(250);
            builder.Property(e => e.OtherReligiousInformation)
              .HasMaxLength(250);
            builder.Property(e => e.AboutMe)
          .HasMaxLength(6000);
            builder.Property(e => e.CandidateAssetDetails)
          .HasMaxLength(600);
            builder.Property(e => e.RegistrationId)
              .HasMaxLength(50);
            builder.Property(e => e.DisabilityDescription)
                .HasMaxLength(600);
            builder.Property(e => e.NativePlace)
                .HasMaxLength(50);
            builder.Property(e => e.EducationDetails)
              .HasMaxLength(300);
            builder.HasIndex(e => e.ProfileId)
              .IsUnique();
            builder.Property(e => e.LastLogIn)
              .HasColumnType("timestamp with time zone");
            builder.Property(e => e.LastUpdated)
              .HasColumnType("timestamp with time zone");
            builder.Property(e => e.IsFinderData)
             .HasDefaultValue(false);
            builder.Property(e => e.IsFeatured)
           .HasDefaultValue(false);
            builder.Property(e => e.IsMatchFilter).HasDefaultValue(false);
            builder.Property(e => e.IsPaidFilter).HasDefaultValue(false);
            builder.Property(e => e.IsAgeFilter).HasDefaultValue(false);
            builder.Property(e => e.IsHeightFilter).HasDefaultValue(false);
            builder.Property(e => e.IsHiddenFilter).HasDefaultValue(false);
            builder.Property(e => e.IsNearMeFilter).HasDefaultValue(true);
            builder.Property(e => e.IsBlacklisted).HasDefaultValue(false);
            builder.Property(e => e.IsOnline).HasDefaultValue(false).IsRequired();
            builder.HasIndex(e => e.MigrationId);
        }
    }
}