using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_finder_be_schedulers_donetcore.Common;
public class SchedulerRunConfiguration : IEntityTypeConfiguration<SchedulerRunBookModel>
{
    public void Configure(EntityTypeBuilder<SchedulerRunBookModel> builder)
    {
        builder.ToTable("scheduler_run_book");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Status).HasMaxLength(100);
        builder.Property(e => e.ProcessStartTime).HasColumnType("timestamp with time zone").IsRequired();
        builder.Property(e => e.ProcessEndTime).HasColumnType("timestamp with time zone").IsRequired();
    }
}
