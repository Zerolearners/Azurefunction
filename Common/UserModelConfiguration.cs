using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("user");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(50);
            //builder.Property(m => m.EmailId).IsRequired();
            builder.HasIndex(e => e.EmailId).IsUnique();
            builder.Property(m => m.PhoneNumber).HasColumnType("jsonb");
            // builder.HasIndex(e => e.PhoneNumber).IsUnique();
            builder.Property(e => e.PasswordHash).IsRequired();
            builder.Property(e => e.PasswordSalt).IsRequired();
            builder.Property(e => e.EmailTokenGeneratedTimestamp)
                .HasColumnType("timestamp without time zone");
            builder.Property(e => e.PhoneTokenGeneratedTimestamp)
                .HasColumnType("timestamp without time zone");
            builder.Property(e => e.OtpRequestUpdatedTimeStamp)
                .HasColumnType("timestamp with time zone");
            builder.Property(e => e.PasswordResetTokenUpdatedTimeStamp)
                .HasColumnType("timestamp with time zone");
            builder.Property(e => e.OtpRequestStartTimeStamp)
                .HasColumnType("timestamp with time zone");
            builder.Property(e => e.PasswordResetTokenStartTimeStamp)
                .HasColumnType("timestamp with time zone");
            builder.Property(e => e.PasswordResetOtpRequestStartTimeStamp)
                .HasColumnType("timestamp with time zone");
            builder.Property(e => e.PasswordResetOtpRequestUpdatedTimeStamp)
                .HasColumnType("timestamp with time zone");
        }
    }
}