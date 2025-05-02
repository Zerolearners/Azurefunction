using System.ComponentModel.DataAnnotations;
using ai_finder_be_schedulers_donetcore.Common;
using ai_finder_be_schedulers_donetcore.Features.Email;

namespace ai_finder_be_schedulers_donetcore.Features.MyMatches
{
    public class CandidateMailMatchModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        public DateTime MatchSentTimestamp { get; set; }
        [Required]
        public EmailNotificationDataModel EmailNotificationData { get; set; }
        public long[] MatchCandidates { get; set; }
    }
}