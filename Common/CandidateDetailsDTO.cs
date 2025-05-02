namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateDetailsDTO
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string Height { get; set; }
        public string MaritalStatus { get; set; }
        public string Name { get; set; }
        public bool IsCelestial { get; set; }
        public string ProfileId { get; set; }
        public int? Age { get; set; }
        public string Denomination { get; set; }
        public string Education { get; set; }
        public string Workplace { get; set; }
        public string ReligionTreePath { get; set; }
        public string Occupation { get; set; }
        public string FatherName { get; set; }
        public GenderModel gender { get; set; }
        public CandidateContactDetailsDTO ContactDetails { get; set; }
        public CandidateSubscriptionModel candidateSubscription { get; set; }
    }
}