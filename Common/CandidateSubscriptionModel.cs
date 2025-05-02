using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateSubscriptionModel
    {
        public long Id { get; set; }

        [Required]
        public CandidateModel Candidate { get; set; }

        [Required]
        public SubscriptionModel Subscription { get; set; }
        public DateTime? StartTimeStamp { get; set; }
        public DateTime? EndTimeStamp { get; set; }
        public bool IsSubscriptionActive { get; set; }
        public int? DailyMessageSentLimit { get; set; }
        public int? DailyMessageSentCount { get; set; }
        public DateTime? LastMessageSentTimeStamp { get; set; }
        public int? TotalContactViewCount { get; set; }
        public int? BalanceContactViewCount { get; set; }
        public int? DailyContactViewLimit { get; set; }
        public int? DailyContactViewCount { get; set; }
        public DateTime? LastContactViewTimestamp { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}