namespace ai_finder_be_schedulers_donetcore.Common
{
    public interface IMatches
    {
        Task<List<CandidateAndSubscriptionDTO>> SendPushData(string[] membershipCodes);
        Task<List<CandidateAndSubscriptionDTO>> SendPushData(string[] membershipCodes, int quarter);

        Task<List<CandidateDetailsDTO>> CandidateSearchByMyMatchV2(long candidateId, long genderId, string[] membershipCodes);
    }
}