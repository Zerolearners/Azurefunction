using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateContactModelConfiguration : IEntityTypeConfiguration<CandidateContactModel>
    {
        public void Configure(EntityTypeBuilder<CandidateContactModel> builder)
        {
            builder.ToTable("candidate_contact");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Relation).HasMaxLength(50);
            builder.Property(e => e.PreferredTime).HasMaxLength(250);
            builder.Property(e => e.LandPhone).HasColumnType("jsonb");
            builder.Property(e => e.IsLandPhoneValidated).HasDefaultValue<bool>(false);
            builder.Property(e => e.MobilePhone).HasColumnType("jsonb");
            builder.Property(e => e.IsMobilePhoneValidated).HasDefaultValue<bool>(false);
            builder.Property(e => e.WhatsApp).HasColumnType("jsonb");
            builder.Property(e => e.IsWhatsAppValidated).HasDefaultValue<bool>(false);
            builder.Property(e => e.Address).HasColumnType("jsonb");
            builder.Property(e => e.Email).HasColumnType("jsonb");
            builder.Property(e => e.IsEmailValidated).HasDefaultValue<bool>(false);
            builder.Property(e => e.Pincode).HasMaxLength(11);
            builder.Property(e => e.IsPincodeValidated).HasDefaultValue<bool>(false);
        }
    }
}