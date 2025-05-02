using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredIncomeModelConfiguration : IEntityTypeConfiguration<PreferredIncomeModel>
    {

        public void Configure(EntityTypeBuilder<PreferredIncomeModel> builder)
        {
            builder.ToTable("prefered_income");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}