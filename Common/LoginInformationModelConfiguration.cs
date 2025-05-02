using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class LoginInformationModelConfiguration : IEntityTypeConfiguration<LoginInformationModel>
    {
        public void Configure(EntityTypeBuilder<LoginInformationModel> builder)
        {
            builder.ToTable("login_information");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Timestamp).HasColumnType("timestamp with time zone");
            builder.Property(x => x.IPAddress).HasColumnType("jsonb");
            builder.Property(x => x.Latitude).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Longitude).HasMaxLength(100).IsRequired();
            builder.Property(x => x.BrowsingAppName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NetworkworkProviderName).HasMaxLength(100);
            builder.Property(x => x.JwtToken).IsRequired();
        }
    }
}