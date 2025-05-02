namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateAndSubscriptionDTO
    {
        public CandidateModel candidate { get; set; }
        public CandidateSubscriptionModel candidateSubscription { get; set; }
        public SubscriptionModel subscription { get; set; }
        public CandidateContactModel candidateContact { get; set; }

    }
}