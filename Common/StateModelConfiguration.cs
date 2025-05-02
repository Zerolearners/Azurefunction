using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class StateModelConfiguration : IEntityTypeConfiguration<StateModel>
    {
        public void Configure(EntityTypeBuilder<StateModel> builder)
        {
            builder.ToTable("state");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.Name)
                .IsRequired().HasMaxLength(250);
            builder.Property(e => e.DisplayName)
                .HasColumnType("jsonb");
            builder.Property(e => e.Code)
                .HasMaxLength(50);
            builder.HasIndex(e => e.Code)
                .IsUnique();
            builder.Property(e => e.IsChildRelation)
                .HasDefaultValue<bool>(false);
        }
    }
}