namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateModel
    {
    public long Id { get; set; }
    public string ProfileId { get; set; }
    public string Name { get; set; }
    public GenderModel Gender { get; set; }
    public ComplexionModel Complexion { get; set; }
    public BodyTypeModel BodyType { get; set; }
    public MaritalStatusModel MaritalStatus { get; set; }
    public int? ChildrenWithMe { get; set; }
    public int? ChildrenNotWithMe { get; set; }
    public BloodGroupModel BloodGroup { get; set; }
    public CountryModel ResidentCountry { get; set; }
    public StateModel ResidentState { get; set; }
    public DistrictModel ResidentDistrict { get; set; }
    public TownModel ResidentTown { get; set; }
    public ResidentTypeModel ResidentType { get; set; }
    public CountryModel NativeCountry { get; set; }
    public StateModel NativeState { get; set; }
    public DistrictModel NativeDistrict { get; set; }
    public TownModel NativeTown { get; set; }
    public string NativePlace { get; set; }
    public CandidateModel TwinsCandidate { get; set; }
    public LanguageModel MotherTongue { get; set; }
    public AddressTypeModel CreatedContact { get; set; }
    public SourceModel Source { get; set; }
    public string ReligionTreePath { get; set; }
    public DateTime DOB { get; set; }
    public bool? IsSpecialNeeds { get; set; }
    public bool? IsResident { get; set; }
    public long? HeightInCentimeter { get; set; }
    public short? WeightInKilogram { get; set; }
    public string OtherReligion { get; set; }
    public string OtherReligiousInformation { get; set; }
    public string AboutMe { get; set; }
    public string CandidateAssetDetails { get; set; }
    public string RegistrationId { get; set; }
    public string DisabilityDescription { get; set; }
    public string EducationDetails { get; set; }
    public bool IsMagazineSend { get; set; }
    public DateTime? LastLogIn { get; set; }
    public DateTime? LastUpdated { get; set; }
    public string MobilePageHash { get; set; }
    public ConfidentialFilterModel Confidential { get; set; }
    public bool? IsMatchFilter { get; set; }
    public bool? IsPaidFilter { get; set; }
    public bool? IsAgeFilter { get; set; }
    public bool? IsHeightFilter { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public long? MigrationId { get; set; }
    public bool IsFinderData { get; set; }
    public bool? IsFeatured { get; set; }
    public bool? IsHiddenFilter { get; set; }
    public bool? IsNearMeFilter { get; set; }
    public bool? IsBlacklisted { get; set; }
    public bool? IsOnline { get; set; }
    }
}