namespace ai_finder_be_schedulers_donetcore.Common
{
    public class AuditPropertyModel
    {
        public string ActivityType { get; set; }
        public long? ActivityId { get; set; }
        public string ActivityTypeCode { get; set; }
        public string ActivityDescription { get; set; }
        public long? ActivityBy { get; set; }
        public DateTime? ActivityTimeStamp { get; set; }
        public string SourcePageHash { get; set; }
    }
}