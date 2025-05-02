namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidatePartnerSearch
    {
        public long Id { get; set; }
        public string CandidateName { get; set; }
        public string ProfileId { get; set; }
        public string RegistrationId { get; set; }
        public long Age { get; set; }
        public long? HeightInCentimeter { get; set; }
        public string Complexion { get; set; }
        public string MaritalStatus { get; set; }
        public string ProfessionDetails { get; set; }
        public string Organization { get; set; }
        public string WorkingCountry { get; set; }
        public string WorkingState { get; set; }
        public string WorkingDistrict { get; set; }
        public string WorkingTown { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionColor { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public long? SubscriptionId { get; set; }
        public string EducationDetails { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? LastLogIn { get; set; }
        public string NativePlace { get; set; }
        public string GenderCode { get; set; }
        public string ProfessionCategoryName { get; set; }
        public bool IsPremium { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsWishlisted { get; set; }
        public string CometId { get; set; }
        public string ReligionTreePath { get; set; }
    }
}