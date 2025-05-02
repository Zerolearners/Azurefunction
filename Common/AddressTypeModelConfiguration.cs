using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class AddressTypeModelConfiguration : IEntityTypeConfiguration<AddressTypeModel>
    {
        public void Configure(EntityTypeBuilder<AddressTypeModel> builder)
        {
            builder.ToTable("address_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.DisplayName)
                .HasColumnType("jsonb");
            builder.Property(e => e.Code)
                .HasMaxLength(5);
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.IsLegacyItem)
           .HasDefaultValue(false);
        }
    }
}