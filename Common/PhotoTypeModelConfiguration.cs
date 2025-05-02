using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PhotoTypeModelConfiguration : IEntityTypeConfiguration<PhotoTypeModel>
    {
        public void Configure(EntityTypeBuilder<PhotoTypeModel> builder)
        {
            builder.ToTable("photo_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Code).HasMaxLength(5).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}