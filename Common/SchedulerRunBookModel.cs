namespace ai_finder_be_schedulers_donetcore.Common;

public class SchedulerRunBookModel
{
    public long Id { get; set; }
    public NotificationCategoryModel Notification { get; set; }
    public DateTime ProcessStartTime { get; set; }
    public DateTime ProcessEndTime { get; set; }
    public string Status { get; set; }
    public long BatchStart { get; set; }
    public long BatchEnd { get; set; }
}
