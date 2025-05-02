using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class MessageCategoryModelConfiguration : IEntityTypeConfiguration<MessageCategoryModel>
    {
        public void Configure(EntityTypeBuilder<MessageCategoryModel> builder)
        {
            builder.ToTable("message_category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Code).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
        }
    }
}