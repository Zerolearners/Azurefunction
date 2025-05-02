using ai_finder_be_schedulers_donetcore.Common;
using ai_finder_be_schedulers_donetcore.Features.Email;
using ai_finder_be_schedulers_donetcore.Features.MyMatches;
using ai_finder_be_schedulers_donetcore.Features.PushNotification;
using ai_finder_be_schedulers_donetcore.Features.Sms;
using ai_finder_be_schedulers_donetcore.Features.WhatsApp;
using Microsoft.EntityFrameworkCore;
namespace ai_finder_be_schedulers_donetcore;
public class FinderSchedulerDbContext : DbContext
{

    public FinderSchedulerDbContext(DbContextOptions<FinderSchedulerDbContext> options) : base(options)
    {
    }
    public DbSet<EmailNotificationDataModel> EmailNotificationDatas { get; set; }
    public DbSet<SmsNotificationDataModel> Sms { get; set; }
    public DbSet<SchedulerRunBookModel> SchedulerRunBooks { get; set; }
    public DbSet<WhatsappNotificationDataModel> Whatsapps { get; set; }
    public DbSet<DeviceInformationModel> DeviceInformations { get; set; }
    public DbSet<NotificationAlertDataModel> NotificationAlertDatas { get; set; }
    public DbSet<LookupSettingModel> LookupSettings { get; set; }
    public DbSet<LookupTypeModel> lookupTypes { get; set; }
    public DbSet<LoginInformationModel> loginInformations { get; set; }
    public DbSet<DeviceInformationModel> deviceInformations { get; set; }
    public DbSet<CandidateModel> candidates { get; set; }
    public DbSet<CandidateSubscriptionModel> candidateSubscriptions { get; set; }
    public DbSet<SubscriptionModel> subscriptions { get; set; }
    public DbSet<PreferenceModel> preferences { get; set; }
    public DbSet<PreferredMaritalStatusModel> preferredMaritalStatuses { get; set; }
    public DbSet<PreferredLanguageModel> preferredLanguages { get; set; }
    public DbSet<PreferredBodyTypeModel> preferredBodyTypes { get; set; }
    public DbSet<PreferredComplexionModel> preferredComplexions { get; set; }
    public DbSet<PreferredCreatorModel> preferredCreators { get; set; }
    public DbSet<PreferredProfessionModel> preferredProfessions { get; set; }
    public DbSet<PreferredOrganizationTypeModel> preferredOrganizationTypes { get; set; }
    public DbSet<PreferredIncomeModel> preferredIncomes { get; set; }
    public DbSet<PreferredLocationModel> preferredLocations { get; set; }
    public DbSet<PreferredFamilyStatusModel> preferredFamilyStatuses { get; set; }
    public DbSet<PreferredEducationModel> preferredEducations { get; set; }
    public DbSet<PreferredSpecialNeedsModel> preferredSpecialNeeds { get; set; }
    public DbSet<PreferredReligionModel> preferredReligions { get; set; }
    public DbSet<ReligionModel> religions { get; set; }
    public DbSet<BodyTypeModel> bodyTypes { get; set; }
    public DbSet<ComplexionModel> complexions { get; set; }
    public DbSet<CandidateEducationModel> candidateEducations { get; set; }
    public DbSet<EducationModel> educations { get; set; }
    public DbSet<FamilyStatusModel> familyStatuses { get; set; }
    public DbSet<CandidateFamilyModel> candidateFamilies { get; set; }
    public DbSet<CandidateProfessionModel> candidateProfessions { get; set; }
    public DbSet<IncomeModel> incomes { get; set; }
    public DbSet<MaritalStatusModel> maritalStatuses { get; set; }
    public DbSet<OrganizationTypeModel> organizationTypes { get; set; }
    public DbSet<AddressTypeModel> addressTypes { get; set; }
    public DbSet<ProfessionModel> professions { get; set; }
    public DbSet<CountryModel> countries { get; set; }
    public DbSet<StateModel> states { get; set; }
    public DbSet<DistrictModel> districts { get; set; }
    public DbSet<TownModel> towns { get; set; }
    public DbSet<CandidatePartnerSearch> candidatePartnerSearches { get; set; }
    public DbSet<InterestMessageModel> interestMessages { get; set; }
    public DbSet<CandidatePhotoModel> candidatePhotos { get; set; }
    public DbSet<PhotoTypeModel> photoTypes { get; set; }
    public DbSet<PhotoPrivacyPolicyTypeModel> photoPrivacyPolicyTypes { get; set; }
    public DbSet<GenderModel> Gender { get; set; }
    public DbSet<LanguageModel> languages { get; set; }
    public DbSet<NotificationCategoryModel> notificationCategories { get; set; }
    public DbSet<CandidateContactModel> candidateContacts { get; set; }
    public DbSet<CandidateMailMatchModel> candidateMailMatches { get; set; }
    public DbSet<PageInfoModel> Pageinfo { get; set; }
    public DbSet<PhotoResponseUrl> PhotoResponseUrl { get; set; }
    public DbSet<AlertGroupsModel> alertGroups { get; set; }
    public DbSet<CandidateAlertSettingsModel> candidateAlertSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhotoResponseUrl>().HasNoKey();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinderSchedulerDbContext).Assembly);
    }


}
