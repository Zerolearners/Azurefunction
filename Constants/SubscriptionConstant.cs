using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ai_finder_be_schedulers_donetcore.Common;

namespace ai_finder_be_schedulers_donetcore.Constants
{
    public class SubscriptionConstant
    {
        public const string DiamondCode = "PAE";
        public const string DiamondPlusCode = "DP";
        public const string GoldCode = "PAP";
        public const string CelestialCode = "CL";
        public const string GoldPlusCode = "GP";
        public const string BronzeCode = "BP";
        public const string SilverCode = "PA";
        public const string NonCatholicDiamond = "NPAE";
        public const string NonCatholicGold = "NPAP";
        public const string Free = "FM";
        public const string UGPCode = "UGP";

        public const string ExpiredSilver = "EP";
        public const string ExpiredCelestial = "ECL";
        public const string ExpiredDiamond = "EPE";
        public const string ExpiredDiamondPlus = "EDP";
        public const string ExpiredGoldPlus = "EGP";
        public const string ExpiredGold = "EPP";
        public const string ExpiredBronze = "EBP";
        public const string ExpiredON = "EON";

        public const string ExpiredNonCatholicDiamond = "ENPAE";
        public const string ExpiredNonCatholicGold = "ENPAP";
        public const string ExpiredXpressCode = "EXM";
        public const string ExpiredUGPCode = "EUG";

        public const string DiamondGracePeriodCode = "GPAE";
        public const string DiamondPlusGracePeriodCode = "GDP";
        public const string GoldGracePeriodCode = "GPAP";
        public const string CelestialGracePeriodCode = "GCL";
        public const string GoldPlusGracePeriodCode = "GGP";
        public const string BronzeGracePeriodCode = "GBP";
        public const string SilverGracePeriodCode = "GPA";

        public const string HiddenCode = "HD";
        public const string BasicConfidentialCode = "BCONF";
        public const string PremiumConfidentialCode = "PCONF";
        public const string TestConfidentialCode = "TCONF";
        public const string BlacklistCode = "BKLST";

        public static readonly string[] SubscriptionPaidType = { GoldCode, DiamondCode, GoldPlusCode, CelestialCode, DiamondPlusCode, BronzeCode, SilverCode, "PAB", NonCatholicDiamond, NonCatholicGold };
        public static readonly string[] SubscriptionWithPaidFunctionalityTypes = { GoldCode, DiamondCode, GoldPlusCode, CelestialCode, DiamondPlusCode, BronzeCode, SubscriptionTypeMA, SilverCode, "PAB" };
        public static readonly string[] SubscriptionExpiredPaidType = { ExpiredSilver, ExpiredCelestial, ExpiredDiamond, ExpiredGoldPlus, ExpiredDiamondPlus, ExpiredBronze, "EPA", "EXP", ExpiredGold, "EB", ExpiredNonCatholicDiamond, ExpiredNonCatholicGold };
        public static readonly string[] SubscriptionExpiredPaidTypeWithGracePeriod = { SilverGracePeriodCode, BronzeGracePeriodCode, GoldPlusGracePeriodCode, CelestialGracePeriodCode, GoldGracePeriodCode, DiamondGracePeriodCode, DiamondPlusGracePeriodCode, ExpiredSilver, ExpiredCelestial, ExpiredDiamond, ExpiredGoldPlus, ExpiredDiamondPlus, ExpiredBronze, ExpiredGold, ExpiredNonCatholicGold, ExpiredNonCatholicDiamond };
        public static readonly string[] SubscriptionFreeType = { "FM", "ON" };
        public static readonly string[] SubscriptionExpiredFreeType = { SubscriptionTypeEX, ExpiredON };
        public static readonly string[] ReregistrationSubscriptions = { GoldCode, DiamondCode, GoldPlusCode, CelestialCode, DiamondPlusCode, BronzeCode, SilverCode, ExpiredSilver, ExpiredCelestial, ExpiredDiamond, ExpiredGoldPlus, ExpiredDiamondPlus, ExpiredBronze, "EPA", "NV" };
        public static readonly string[] SubscriptionActiveType = { GoldCode, DiamondCode, GoldPlusCode, CelestialCode, DiamondPlusCode, BronzeCode, SilverCode, "PAB", SubscriptionTypeON };

        public static readonly string[] SubscriptionsDefault = { DiamondPlusCode, DiamondCode, GoldCode, CelestialCode };
        public static readonly string[] SubscriptionWithBronze = { DiamondPlusCode, DiamondCode, GoldCode, BronzeCode };
        public static readonly string[] SubscriptionWithSilver = { DiamondPlusCode, DiamondCode, GoldCode, SilverCode };
        public static readonly string[] SubscriptionWithGoldPlus = { DiamondPlusCode, DiamondCode, GoldCode, GoldPlusCode };

        public static readonly string[] ComparePlansDefault = { SubscriptionTypeON, DiamondPlusCode, DiamondCode, GoldCode, CelestialCode };
        public static readonly string[] ComparePlansWithBronze = { SubscriptionTypeON, DiamondPlusCode, DiamondCode, GoldCode, BronzeCode };
        public static readonly string[] ComparePlansWithSilver = { SubscriptionTypeON, DiamondPlusCode, DiamondCode, GoldCode, SilverCode };
        public static readonly string[] ComparePlansWithGoldPlus = { SubscriptionTypeON, DiamondPlusCode, DiamondCode, GoldCode, GoldPlusCode };

        public static readonly string[] UnPaidSubscriptionSearchById = { SubscriptionTypeEX, SubscriptionTypeON };
        public static readonly string[] NonCatholicType = { NonCatholicDiamond, NonCatholicGold };


        public const string SubscriptionJustCompletedType = "JC";
        public const string SubscriptionInvalidType = "NV";
        public const string SubscriptionTypeFilePath = @"Features/Subscription/SubscriptionStatus.json";
        public const string SubscriptionTypeON = "ON";
        public const string SubscriptionTypeFM = "FM";
        public const string SubscriptionTypeMA = "MA";
        public const string SubscriptionTypeEX = "EX";
        public const string PaidMemberShip = "Premium Membership";
        public const string FreeMemberShip = "Free Membership";
        public const string InCompletedProfile = "Incomplete Profile";
        public const string ExpiredPaidMemberShip = "Expired Premium Membership";
        public const string ExpiredFreeMemberShip = "Expired Free Membership";
        public const string MAMemberShip = "Xpress Membership";
        public const string ExpiredMAMemberShip = "Expired Xpress Membership";
        public const string FreeMemberShipON = "Free Membership";
        public const string UGPMemberShip = "UGP Membership";
        public const string ExpiredUGPMemberShip = "Expired UGP Membership";
        public const string SubscriptionTypeJC = "JC";
        public const string SubscriptionNameTailEnd = "Membership";
        public static readonly long[] SubscriptionPaidTypeId = { 9, 4, 5, 3, 12, 2, 1, 7, 19, 6 };
        public static readonly long[] SubscriptionExpiredPaidTypeId = { 14, 13, 20, 16, 17, 15, 28, 22 };
        public const string PaidMemebershipActive = "PACT";
        public const string FreeMembershipOnActive = "OACT";
        public const string FreeMembershipFmActive = "FACP";
        public const string XpressMembershipActive = "XACT";
        public const string UGPMembershipActive = "UGACT";
        public const string ExpiredPaid = "EXPP";
        public const string ExpiredFree = "EXPF";
        public const string ExpiredXpress = "EXMA";
        public const string ExpiredUGP = "EXUGP";
        public const string PaidMemebershipInActive = "PINA";
        public const string PaidMemebershipInActiveBefore30DaysOfExpiry = "PINAB3E";
        public const string PaidMemebershipInActiveAfter30DaysOfExpiry = "PINAA3E";
        public const string FreeMembershipFmInactive = "FACT";
        public const string FreeMembershipOnInactive = "OINA";
        public const string Incomplete = "INC";
        public const string ExpiredPaidAfter365Days = "EXPPE";
        public const string ExpiredFreeAfter365Days = "EXPFE";
        public const string InActiveEX = "EXINA";
        public const string InActiveEON = "EONINA";
        public const string InActiveXpress = "XINA";
        public const string InActiveUGP = "UGINA";
        public static readonly string[] InActiveExpiredFreeMembers = { InActiveEX, InActiveEON };
        public static readonly string[] ArchivedSubscriptionStatus = { ExpiredPaidAfter365Days, ExpiredFreeAfter365Days };
        public static readonly string[] CandidateListShowOrder = { PaidMemebershipActive, FreeMembershipOnActive, UGPMembershipActive, XpressMembershipActive, FreeMembershipFmActive, ExpiredPaid, ExpiredFree, ExpiredUGP, ExpiredXpress, Incomplete, PaidMemebershipInActiveBefore30DaysOfExpiry, PaidMemebershipInActiveAfter30DaysOfExpiry, PaidMemebershipInActive, FreeMembershipFmInactive, FreeMembershipOnInactive, InActiveEX, InActiveEON, InActiveUGP, InActiveXpress };
        public const string EliteProfileCode = "ELP";
        public const string PhotoRepublishCode = "PRP";
        public const string HighlightedProfileCode = "HLP";
        public const string OtherPaymentCode = "OP";
        public const int GraceperiodValidity = 30;
        public const int ExpireSoonWarningShowDays = 30;
        public const int InvalidPremiumMemberValidationDays = 30;
        public const int ExpireSoonWarningShowDaysForBronze = 10;
        public const int ExpireSoonWarningShowDaysForON = 15;
        public const int ExipryExipringDaysLimit = 365;
        public const int JCArchiveDaysLimit = 180;
        public static readonly string[] SubscriptionCategoryCodes = { "PREM", "FREEM", "INVM", "EPREM", "EFREEM" };
        public const string ActivateMemberShip = "Membership activated by";

        public const string ChangeMemberShip = "You have successfully changed the memberships";
        public static string SubscriptionName = $"{ReplacingConstant.Name} Membership {ReplacingConstant.ProfileVisibility}";
        public const string HiddenDisplayName = "(Hidden)";
        public const string HiddenName = "Hidden";
        public const string ConfidentialDisplayName = "(Confidential)";
        public const string GracePeriodCategory = "GCM";
        public const string ConfidentialCategory = "CONFM";
        public static readonly string[] SubscriptionCodeNotInSwitchCandidate = { SubscriptionInvalidType, SubscriptionJustCompletedType };

        public const string SubscriptionCategoryPremiumCode = "PREM";
        public const string SubscriptionCategoryFreeCode = "FREEM";
        public const string SubscriptionCategoryExpiredPremiumCode = "EPREM";
        public const string SubscriptionCategoryExpiredFreeCode = "EFREEM";
        public const string SubscriptionCategoryInActiverCode = "INVM";
        public static readonly string[] ActiveSubscriptionCategoriesCodes = { SubscriptionCategoryPremiumCode, SubscriptionCategoryFreeCode };
        public static readonly string[] ReregisterSubscriptionCategoryCodes = { SubscriptionCategoryPremiumCode, GracePeriodCategory, SubscriptionCategoryExpiredPremiumCode };
        public static readonly string[] PriorSubscriptionCategoriesForPolicy = { SubscriptionCategoryExpiredPremiumCode, SubscriptionCategoryExpiredFreeCode, SubscriptionCategoryInActiverCode };
        public static readonly string[] ExpiredSubscriptionCategories = { SubscriptionCategoryExpiredPremiumCode, SubscriptionCategoryExpiredFreeCode };
        public static readonly string[] ExpiredPaidSubscriptionCategories = { SubscriptionCategoryExpiredPremiumCode, GracePeriodCategory };
        public const string ReRegistration = "Re-Registration";
        public const string ReRegistrationCode = "REREG";
        public const string FreshRegistration = "Fresh Registration";
        public const string Registration = "Registration";
        public const string FreshRegistrationCode = "FREG";
        public const string OtherRegistrationCode = "OTH";
        public const string OtherRegistration = "Other";
        public const string UpdateSubscriptionDate = "You have successfully updated the added date/expiry date.";
        public const string SubscriptionCategoryGracePeriodCode = "GCM";

        public const string FreeInvalidCode = "FTNV";
        public const string PaidToInvalidCode = "PTNV";
        public const string ArchivePaidToInvalidCode = "EEXNV";
        public const string JCToInvalidCode = "JCTNV";
        public const string ArchivedJCToInvalidCode = "JETNV";
        public const string ActivablePaidToInvalidCode = "PATNV";
        public const string FMToInvalidCode = "FMTNV";
        public const string ExpressGracePeriod = "GEXM";
        public const string UGPGracePeriod = "GEUG";

        public const string NonCatholicDenominationCode = "ab062f11-6079-4619-b91a-d16852d2a0e8";
        public static readonly string[] SubscriptionPaidCategory = { SubscriptionCategoryGracePeriodCode, SubscriptionCategoryPremiumCode };
        public static readonly string[] SubscriptionGraceAndExpiredCategory = { SubscriptionCategoryGracePeriodCode, SubscriptionCategoryExpiredPremiumCode };
        public static readonly string[] ExcludeFreeMemFromGracePeriod = { ExpressGracePeriod, UGPGracePeriod };
        public static readonly string[] AllFreeMemBer = { SubscriptionCategoryFreeCode, SubscriptionCategoryExpiredFreeCode };
        public static readonly string[] ExcludeFreeMembersFromFreeCount = { UGPCode, SubscriptionJustCompletedType, SubscriptionTypeMA, ExpiredXpressCode, ExpiredUGPCode, "VA", "NC", "EB" };
        public static readonly string[] FreeMemeberXpress = { SubscriptionTypeMA, ExpiredXpressCode };
        public static readonly string[] AllUGPMembersCategory = { SubscriptionCategoryGracePeriodCode, SubscriptionCategoryFreeCode, SubscriptionCategoryExpiredFreeCode };
        public static readonly string[] AllUGPMembers = { UGPCode, ExpiredUGPCode, UGPGracePeriod };
        public const string PaidMember = "Paid member";
        public const string FreeMember = "Free member";
        public const string XpressMember = "Xpress member";
        public const string UGPMember = "UGP member";
        public const string JCMember = "JC";
        public const string InvalidMember = "Invalid";

        public const string ActivationCelestialCode = "CCEL";
        public const string EPM = "EPM";
        public const string EPA = "EPA";
        public static readonly string[] FreeMembersForCount = { SubscriptionTypeFM, SubscriptionTypeON, SubscriptionTypeEX, ExpiredON };
        public static readonly string[] ExpressAndUGP = { UGPCode, SubscriptionTypeMA, ExpressGracePeriod, UGPGracePeriod, };

        public const string Xpress = "Xpress";
        public const int XpressId = 6;
        public static readonly string[] NameVisibilityRestrictedSubscriptionCodes = { SubscriptionTypeFM, SubscriptionTypeON, SubscriptionTypeEX, ExpiredON };
        public const string HiddenCandidateName = "*****";
    }
}