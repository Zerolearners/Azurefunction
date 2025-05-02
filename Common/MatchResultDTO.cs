namespace ai_finder_be_schedulers_donetcore.Common
{
    public class MatchResultDTO
    {
        public long CandidateId { get; set; }
        public string Name { get; set; }
        public string ProfileId { get; set; }
        public string RegistrationId { get; set; }
        public long Age { get; set; }
        public long? HeightInCentimeter { get; set; }
        public string Complexion { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string EducationDetails { get; set; }
        public ProfessionDTO Profession { get; set; }
        public SubscriptionDTO Subscription { get; set; }
        public bool IsOnline { get; set; }

        public long? GenderId { get; set; }
        public string Gender { get; set; }
        public string CustodianName { get; set; }
        public long? MaritalStatusId { get; set; }
        public string SubCaste { get; set; }
        public long? EducationId { get; set; }
        public long? DenominationId { get; set; }
        public long? OccupationId { get; set; }
        public DateTime? LastLogIn { get; set; }
        public DateTime? AddedDate { get; set; }
        public long SubscriptionId { get; set; }
        public CandidateProfessionModel Professions { get; set; }
        public CandidateSubscriptionModel Subscriptions { get; set; }
        public ReligionModel Religions { get; set; }
        public CandidateEducationModel Educations { get; set; }
        public CandidateModel Candidates { get; set; }

        public PhotoDetailsDTO Photos { get; set; }
        public string FatherName { get; set; }
        public string FatherHouseName { get; set; }
        public string WorkingCountry { get; set; }
        public string WorkingState { get; set; }
        public string NativePlace { get; set; }
        public string WorkingDistict { get; set; }
        public string FatherNativePlace { get; set; }
        public string FatherProfession { get; set; }
        public string MotherName { get; set; }
        public string MotherHouseName { get; set; }
        public string MotherNativePlace { get; set; }
        public string MotherProfession { get; set; }
        public string PartnerExpectation { get; set; }
        //  public LandLineModel LandPhone { get; set; }
        public MobileNumberModelDTO MobilePhone { get; set; }
        public MobileNumberModelDTO WhatsApp { get; set; }
        //  public EmailModel Email { get; set; }
        //   public JsonDocument Address { get; set; }
        //   public long TotalPhotoCount { get; set; }
        //  public MessageStatusDTO MessageStatus { get; set; }
        //  public MessageStatusDTO ChatStatus { get; set; }
        //  public ShortListedDTO ShortListedStatus { get; set; }
        public bool IsPremium { get; set; }
        //     public bool IsFeatured { get; set; }
        //   public string ProfessionCategory { get; set; }
        //    public bool? IsWishlisted { get; set; }
        //    public LocationDTO Location { get; set; }
        //  public string CometId { get; set; }
    }
}