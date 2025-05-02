using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateFamilyModelConfiguration : IEntityTypeConfiguration<CandidateFamilyModel>
    {
        public void Configure(EntityTypeBuilder<CandidateFamilyModel> builder)
        {
            builder.ToTable("candidate_family");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
            builder.Property(e => e.FatherName)
            .HasMaxLength(50);
            builder.Property(e => e.FatherHouseName)
           .HasMaxLength(100);
            builder.Property(e => e.FatherNativePlace)
           .HasMaxLength(50);
            builder.Property(e => e.FatherProfession)
           .HasMaxLength(100);
            builder.Property(e => e.MotherName)
          .HasMaxLength(50);
            builder.Property(e => e.MotherHouseName)
           .HasMaxLength(100);
            builder.Property(e => e.MotherNativePlace)
           .HasMaxLength(50);
            builder.Property(e => e.MotherProfession)
          .HasMaxLength(100);
            builder.Property(e => e.AboutFamily)
          .HasMaxLength(6000);
        }
    }
}