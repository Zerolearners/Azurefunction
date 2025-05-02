using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PageInfoModelConfiguration : IEntityTypeConfiguration<PageInfoModel>
    {
        public void Configure(EntityTypeBuilder<PageInfoModel> builder)
        {
            builder.ToTable("page_info");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.HashCode).HasMaxLength(100).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.IsDeleted).HasDefaultValue(false);
            builder.Property(e => e.Url).HasMaxLength(200).IsRequired();
        }
    }
}