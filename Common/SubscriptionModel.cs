namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SubscriptionModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
        public string Description { get; set; }
        public NameInLanguageModel DisplayDescription { get; set; }
        public SubscriptionCategoryModel SubscriptionCategory { get; set; }
        public string Colour { get; set; }
        public string ImageUrl { get; set; }
        public int? Order { get; set; }
        public int? ContactViewCount { get; set; }
        public int? DailyContactViewCount { get; set; }
        public int? DailyMessageSentLimit { get; set; }
        public long? ChildId { get; set; }
        public long Fee { get; set; }
        public long ReRegistrationFee { get; set; }
        public int? DurationInMonth { get; set; }
        public LookupSettingModel Denomination { get; set; }
        public bool? IsAddon { get; set; }
        public bool? IsPremium { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSearchable { get; set; }
        public int VideoCallTimeLimitInMinutes { get; set; }
    }
}