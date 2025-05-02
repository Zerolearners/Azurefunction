using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class DeviceInformationModelConfiguration : IEntityTypeConfiguration<DeviceInformationModel>
    {
        public void Configure(EntityTypeBuilder<DeviceInformationModel> builder)
        {
            builder.ToTable("device_information");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirebaseToken).HasMaxLength(550);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.OSName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.TimeStamp).HasColumnType("timestamp with time zone");
        }
    }
}