using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ActivityTypeConstants
    {
        public const string logOut = "LOGOUT";
        public const string AllLogOut = "3c1f141c-e6f3-4674-b558-2e5b7c57e3d5";
        public const string ForcedLogout = "175f8d1f-d8f3-4074-997c-526807536573";
        public const string logIn = "LOGIN";
        public const string LogInOTPViaMailSend = "1085aea9-d608-4dc1-9e02-f204877b629d";
        public const string LogInOTPViaMobileSend = "41d3ceb7-66e3-4d5d-83ce-f42528ea965c";

        // CPV : View candidate primary info code
        public const string CPV = "CPV";
        // CPV : Update candidate primary info code
        public const string CPU = "CPU";
        // CPV : View candidate religion info code
        public const string CRIV = "CRIV";
        // CPV : View candidate religion info code
        public const string CRIU = "CRIU";
        // CPV : View candidate education and profession info code
        public const string CEPV = "CEPV";
        // CPV : View candidate education and profession info code
        public const string CEPU = "CEPU";
        // CPV : View candidate family info code
        public const string CFIV = "CFIV";
        // CPV : Update candidate family info code
        public const string CFIU = "CFIU";
        // CPV : View candidate location info code
        public const string CLIV = "CLIV";
        // CPV : Update candidate location info code
        public const string CLIU = "CLIU";
        // CPV : Added candidate location contact info code
        public const string CLCIA = "CLCIA";
        // CPV : View candidate contact info code
        public const string CCIV = "CCIV";
        // CPV : Update candidate contact info code
        public const string CCIU = "CCIU";
        // CPV : View candidate hobbies and interest info code
        public const string CHIV = "CHIV";
        // CPV : Update candidate hobbies and interest info code
        public const string CHIU = "CHIU";
        // CPV : View candidate social media info code
        public const string CSMIV = "CSMIV";
        // CPV : Update candidate social media info code
        public const string CSMIU = "CSMIU";
        // CPV : View candidate preference info code
        public const string CPPV = "CPPV";
        // CPV : Update candidate preference info code
        public const string CPPU = "CPPU";
        // CPV : View candidate profile creator info code
        public const string CPCV = "CPCV";
        // CPV : Update candidate  profile creator info code
        public const string CPCU = "CPCU";
        // CPV : View candidate digital magazine info code
        public const string CDMV = "CDMV";
        // CPV : Update candidate   digital magazine info code
        public const string CDMU = "CDMU";
        //EMOTP : OTP send via mail
        public const string EmailOtpSend = "EMOTP";
        //RSPD: Reset User Password
        public const string ResetPassword = "RSPD";
        //RPTSM : Reset Password Token send via mail
        public const string ResetPasswordTokenSend = "RPTSM";
        public const string ResetPasswordOTPSend = "f5bf7241-0972-4ee9-b69f-10a2b752c4d5";
        public const string ActivityFailed = "Failed to add log";
        //Candidate primary and religious information added
        public const string AddedCandidatePrimaryReligiousInfo = "CPRA";
        //Candidate uploaded profile photo
        public const string ProfilePhotoAdded = "PFLPU";
        //Candidate uploaded album photo
        public const string AlbumPhotoAdded = "ALBPU";
        //Candidate uploaded family photo
        public const string FamilyPhotoAdded = "FAMPU";
        //Candidate changed profile photo
        public const string ProfilePhotoChanged = "PFLPC";
        //Candidate changed album photo
        public const string AlbumPhotoChanged = "ALBPC";
        //Candidate changed family photo
        public const string FamilyPhotoChanged = "FAMPC";

        public static readonly string[] PhotoAddedActivityTypeCodes = new string[] { ProfilePhotoAdded, ProfilePhotoChanged, AlbumPhotoAdded, AlbumPhotoChanged, FamilyPhotoAdded, FamilyPhotoChanged };
        //Reject candidate profile photo 
        public const string ProfilePhotoRejected = "PFLPR";
        //Reject candidate album photo 
        public const string AlbumPhotoRejected = "ALBPR";
        //Reject candidate family photo 
        public const string FamilyPhotoRejected = "FAMPR";

        //Accepted candidate profile photo 
        public const string ProfilePhotoAccepted = "PFLPA";
        //Accepted candidate album photo 
        public const string AlbumPhotoAccepted = "ALBPA";
        //Accepted candidate family photo 
        public const string FamilyPhotoAccepted = "FAMPA";
        public const string PhotoArchived = "9664a8e9-1627-4b5f-85d4-f7286f56e0fd";
        public const string PhotoRestored = "54e4c577-1306-486b-90ed-0db1572edef9";
        //Deleted candidate profile photo 
        public const string ProfilePhotoDeleted = "PFLPD";
        //Deleted candidate album photo 
        public const string AlbumPhotoDeleted = "ALBPD";
        //Deleted candidate family photo 
        public const string FamilyPhotoDeleted = "FAMPD";
        //swapped album photo
        public const string AlbumPhotoSwapped = "ALBSW";
        //swapped family photo
        public const string FamilyPhotoSwapped = "FAMSW";

        //Candidate Education and Profession information added
        public const string AddedCandidateEducationProfessionInfo = "CEPA";
        //Candidate mobile verification OTP generated
        public const string CandidateVerificationSMSGenerated = "CVSG";
        //Candidate email verification OTP generated
        public const string CandidateVerificationEmailGenerated = "CVEG";

        //Candidate mobile validated
        public const string CandidateMobileValidated = "CVSV";
        //Candidate email validated
        public const string CandidateEmailValidated = "CVEV";
        public const string CandidateAdditionalPrimaryEducationAndFamilyDetailsAdded = "CPEFA";
        public const string AddedIdProof = "CIDPA";
        public const string UpdatedIdProofTypeAndNumber = "IPTNU";
        public const string UploadedSecondIdProofDocument = "IDP2A";
        public const string UploadedSingleIdProofDocument = "577a972f-91de-49a2-9431-9984010412aa";
        public const string IdProofDeleted = "CIDPD";
        public const string IdProofAccepted = "ACIDP";
        public const string IdProofRejected = "RCIDP";
        public const string IdProofDocumentOneEdited = "IPD1E";
        public const string IdProofDocumentTwoEdited = "IPD2E";
        public const string CandidateDataInIdProofUpdated = "CDIPU";
        public const string IdProofDocumentDeleted = "b448fa52-b5cb-43ca-9ca7-1ad883e58df1";


        public const string CandidatePhotoPrivacyVisibilityAll = "CPPVA";
        public const string CandidatePhotoPrivacyVisibleOnlyAfterAcceptance = "CPPAA";
        public const string CandidatePhotoPrivacyProtectedByPassword = "CPPPD";
        public const string CandidateAllPhotoPrivacyHidePhoto = "CPHD";
        public const string CandidateAlbumPhotoPrivacyHidePhoto = "CAPHD";
        public const string CandidateFamilyPhotoPrivacyHidePhoto = "CFPHD";
        public const string CandidateRegistration = "CREG";

        #region User
        public const string AddedUser = "USRA";
        public const string UpdatedUser = "e0b0cd44-c6eb-414c-8f59-f9fc7e52a653";
        #endregion

        public const string CandidateAdditionalLocationAndContactDetailsAdded = "CALCU";
        public const string ChangePassword = "95a56660-8c08-4483-96cf-4347b31124df";

        #region Message

        public const string MessageSended = "23c3cfe0-8903-11ee-9491-5ec7c1134ee0";
        public const string ChatRequestSent = "02750469-4e70-40fe-a36e-69b33bab0280";
        public const string PhotoUploadRequestSent = "dadfab5b-a20f-40ff-b1c0-b13c7fd97e13";
        public const string PhotoViewRequestSent = "2f3c05e8-8649-4435-9d68-b3c178959c41";
        public const string AlbumPhotoViewRequestSent = "a386bb5b-0d1b-4835-aa37-c6cf8ceadfe0";
        public const string FamilyPhotoViewRequestSent = "6ea561a0-e573-4488-a0bc-8efa84e4d1cd";

        public const string MessageReaded = "e241ed1b-fa77-44ba-98e8-ca34f5c2b20b";
        public const string MessageAccepted = "cf76888c-89da-11ee-be01-5ec7c1134ee0";
        public const string MessageResponded = "f0ceb70c-89da-11ee-be02-5ec7c1134ee0";
        public const string MessageWithdraw = "ad1e90b2-069b-4391-b842-ca6deb00e96d";
        public const string MessageDeclined = "5b00ee6c-8aab-11ee-91b7-5ec7c1134ee0";
        public const string AdminSenderDelete = "bbec8372-6080-4aa0-bb4c-8e2be136fbc4";
        public const string AdminRecieverDelete = "4d53547f-cad0-4137-a48e-fc12342c6d20";
        public const string MessageReceiverDelete = "3febdddf-a1c5-4350-8e95-7519a9e12425";
        public const string MessageSenderDelete = "dfbad13b-dec9-4c51-a53c-6d5f77a74169";
        public const string MessageDeleted = "5dfad4a4-fc97-44e0-9671-25eaaa26fbd3";
        public const string MessagesCleared = "ebcd10db-a18d-4c21-8c9a-eea7b4a238c6";
        public const string MessageSenderTrash = "b02854b6-c5cf-441a-b61c-956b1b854cb1";
        public const string MessageRecieverTrash = "e80f40a6-42ae-4ea2-a8d2-df45160ea0d3";
        public const string MessageTrashed = "9196db95-b6cc-456f-b409-0e42afbed0ba";
        public const string MessageSenderRestored = "5f6c1d86-7de9-4ff2-892c-49c8ab84e3f4";
        public const string MessageRecieverRestored = "7cb4919d-4b9a-4601-8b23-d3acdd4ad8b2";
        public const string MessageRestored = "58dbc8a0-4322-4a18-b7cf-0c8fd2813d35";
        public const string MessageStarred = "08665310-ef76-4dd6-bc3f-d13c788137cd";
        public const string MessageSenderStarred = "61cfec4c-8384-4602-9a12-0097c5d883a5";
        public const string MessageRecieverStarred = "c7c95e9c-43a9-438b-a8c6-84e406c544e2";
        public const string RespondLater = "195b0e05-71ca-45ce-987e-7a40ffbfd955";
        public const string MessageUnstarred = "09b540fa-ef52-4e03-9c75-4e04df7ef1e7";
        public const string MessageSenderUnstarred = "194b9893-bd78-422a-952a-8d220735e3e7";
        public const string MessageRecieverUnstarred = "90f402a0-bb77-4586-8716-ad63d4659074";

        public static readonly string[] HiddenAuditPropertyForContentView = new string[] { MessageSenderTrash, MessageRecieverTrash, MessageSenderRestored, MessageRecieverRestored, MessageReceiverDelete, MessageSenderDelete, MessageReaded, MessageSenderStarred, MessageStarred, MessageRecieverStarred, MessageSenderUnstarred, MessageRecieverUnstarred };

        #endregion

        public const string AdminCleared = "dd400b0e-97f2-47bb-8573-13f3b276a746";

        #region Candidate Operation
        public const string SourceDelete = "d3f173aa-c0df-47fe-b46b-4f7b784dad29";
        public const string TaggedDelete = "7fc9b57b-57f1-4bbc-a3ce-967a62d0b230";
        public const string AdminSourceDelete = "5ae6f7cf-861b-45b7-b411-d420eba78b2d";
        public const string AdminTaggedDelete = "58bcf132-44b5-49c9-8384-15f6e9747836";
        public const string ProfileVisit = "3478ded6-4e02-4d45-bf4c-023534f6dea4";
        public const string ContactVisit = "3478ded6-4e02-4d45-bf4c-023534f6dea4";
        public const string ContactDetailsVisit = "2fa2167c-f47b-4e30-b763-7beb50cf253a";

        #endregion

        #region Candidate Data Change Request
        public const string ChangeRequestSent = "5b301c3a-e517-4549-9062-26322868a423";
        public const string ChangeRequestApproved = "d6cb6253-ff7d-4f92-a358-f56a369e329c";
        public const string ChangeRequestRejected = "f3b381bd-68ea-4eb4-83c2-9af703e5b719";
        public const string ChangeRequestDeleted = "a16be9c2-98e7-436b-9b02-7825913f7a7c";
        #endregion

        #region Candidate Wishlist Code
        public const string AddWishlist = "c17430b1-7f32-4b17-8773-a95dfef0410e";
        public const string DeleteWishlist = "bbd4e912-3591-491b-bd3e-e0ce3b368e58";
        #endregion

        #region Reset Password
        public const string ValidatedResetPasswordOTP = "cdf75851-3e1b-495d-87ae-d1971c1c7ab3";
        public const string FailedValidatedResetPasswordOTP = "95b53338-cfc9-4bdc-bbd0-827d1665001c";

        #endregion

        #region Candidate ProfileList Activities
        public const string Bookmark = "1b3aab6b-09d2-4fd4-a831-8dd51c78505b";
        public const string Block = "0436d9fb-a6ef-4a2e-9801-a3a64e72f01b";
        public const string Ignore = "a31add42-75c2-4c18-ad95-328606c6facc";
        public const string ProfileRemoved = "747b5c4c-880a-4ab8-8efc-7797f24ebef6";
        public const string AddedComment = "0acf352b-f5b5-450d-a536-68a5edcd7d5f";
        public const string EditedComment = "a6aaa8d6-9ef1-4dd4-850a-51f4715e8989";

        #endregion

        #region SuccessStory
        public const string AddedSuccessStory = "ab7a42da-fe03-4b94-a094-2b74c6886275";
        public const string ApprovedSuccessStory = "8fbfc74a-3dfd-4d5b-b980-bdc0aaafa2f0";
        public const string RejectedSuccessStory = "fec85fd6-ef99-4395-8703-fd595e03f3b9";
        public const string DeletedSuccessStory = "a1a4d182-c053-43b7-a445-771607f43990";
        public const string SuccessStoryStatus = "6546226e-b416-4ee5-a0ef-ca01ca160e95";
        public const string EditSuccessStory = "8d689524-b0fb-4e42-814a-bab9a1a39370";

        #endregion

        #region testimonial
        public const string AddedTestimonial = "7e234215-1794-4624-8c90-5c310b2e228d";
        public const string DeletedTestimonial = "9b727f2c-297c-4ba1-ac77-d5a0d64d80e7";
        public const string EditedTestimonial = "0dbf664f-6fbe-49bd-92cc-e82952fd8213";
        #endregion

        #region Switch candidate
        public const string SwitchCandidate = "0f0b50a4-1d9e-410d-bb9a-d662ffc7a3cc";
        #endregion
        #region Comments
        public const string CustomComment = "bfa49113-6cba-4a22-95bd-085b202a13b8";
        public const string MembershipTypeChange = "c1fa75e3-e48e-4ef1-b630-7973d12d79d1";
        public const string DateChange = "2fba9c9d-a56c-4e7e-acbe-19d46db2baa1";
        public const string BranchIdChange = "779af3c7-5d7e-4763-811c-e5d1668f3dac";
        public const string ReactivateProfile = "4d313f65-e844-451f-9166-d63c8a05438e";
        public const string DeleteProfile = "156c44bc-1eff-468f-90ae-65f59be3eebc";
        public const string ChavaraIdChange = "8e634228-22a5-4c0b-b378-eab47c558afe";
        #endregion

        public static readonly string[] UserManipulationSelectedComment = { "bfa49113-6cba-4a22-95bd-085b202a13b8", "c1fa75e3-e48e-4ef1-b630-7973d12d79d1", "2fba9c9d-a56c-4e7e-acbe-19d46db2baa1", "779af3c7-5d7e-4763-811c-e5d1668f3dac", "4d313f65-e844-451f-9166-d63c8a05438e", "156c44bc-1eff-468f-90ae-65f59be3eebc", "8e634228-22a5-4c0b-b378-eab47c558afe", "79c7eaf1-af45-4985-a44d-eca8d1a8d592", "6ee63a04-d6e1-4f52-bb18-2deeafe196ef", "2217b9b6-8bc6-4ef9-ac40-296c1d2d5372", "ac7abcf3-8c50-454c-8096-66156e305a32", "8207a9bd-fd9b-41f0-b084-d3f48eb929ad", "073ae244-8ccb-4bd9-b001-18160aba632a", "b4e52878-4a04-4b3d-b1ef-258817c46ccb", "1b851228-7eec-4c79-8b8e-56c4d73c3d67", "5ba5a461-64d1-40da-83a6-f2bfb4db099f", "cb4798e3-03e1-449a-a70a-532b3d8497df", "12eab9ab-d688-45d5-b9de-1839a702e011", "4d6db6e9-d912-4d29-bec9-cb47f2b58e05", "25f709cf-2879-4922-a968-8950dcc62c55", "22837875-90aa-4117-9295-4cdf2c5ac809", "eff11d71-16ce-4795-a9e8-adbf0403197b", "54cb2197-68d3-4d97-9c7e-591aab593a89", "0f6664fa-bee7-43f4-954c-c79a03a4ebcb", "915adb73-8612-4084-b01a-d07e278ee479", "36876df7-1b36-4102-a2ac-d5b5ef4d62c1", "d801739f-6dc6-46bd-acbb-3cb403c7716e", "3dd9e0c0-9640-4b37-a51c-6f7b1cc51727", "0f6664fa-bee7-43f4-954c-c79a03a4ebcb", "cbddc9bc-b423-4062-bb91-3a6b58c3f83d", "0ed34481-d0a9-4f71-89ae-b665ad2d7991", "d1b7098a-4b25-4b81-8814-3777687a29b8", "22451319-388d-4129-ac88-addf8b82d7e2", "cb662400-9219-47b6-82c7-8c53091c6658", "a4fb7afb-92ab-4c9d-8f40-bd7752598cf0", "2e33e5fb-a25a-4874-a874-b8351da30458", "4f02d38a-19a8-419d-ad02-2ef9c6fabfa2b", "1cc8d558-cdbc-4277-9818-6eefabc7133b", "f749468a-850e-4b4b-b248-4487859e3f97" };

        public static readonly string[] UserManipulationProfileUpdationComments = {
    "CPU",
    "CRIU",
    "CEPU",
    "CFIU",
    "CLIU",
    "CCIU",
    "CHIU",
    "CSMIU",
    "CPPU",
    "CPCU",
    "5b301c3a-e517-4549-9062-26322868a423",
    "5d8abfdd-5c48-4bff-9770-579ea501c4e1",
    "d6cb6253-ff7d-4f92-a358-f56a369e329c",
    "f3b381bd-68ea-4eb4-83c2-9af703e5b719",
    "a16be9c2-98e7-436b-9b02-7825913f7a7c",
    "bfa49113-6cba-4a22-95bd-085b202a13b8"
};

        #region Contact History

        public static readonly string[] ContactHistoryActivities = { MessageSended, ChatRequestSent, MessageAccepted, MessageDeclined };
        #endregion
        #region Candidate Filters
        public const string ApplyMatchFilter = "11bf942a-a4d4-4c9e-95fa-222afc8a5d45";
        public const string ApplyPremiumFilter = "46976a1c-11c7-45eb-a8dd-dd6f7b9c4c15";
        public const string ApplyVisibleToAll = "5ba5a461-64d1-40da-83a6-f2bfb4db099f";
        public const string ApplyAgeFilter = "ef49ac45-0db3-4b97-b955-ed1484975d43";
        public const string ApplyHeightFilter = "162ac39a-3346-4199-b01e-70f82c9d9f45";
        public const string ApplyNearMeFilter = "d81ca0cf-50b0-4f30-be0a-d544afc984dd";
        public const string ApplyHiddenFilter = "79c7eaf1-af45-4985-a44d-eca8d1a8d592";
        public const string ApplyForUnhideFilter = "2217b9b6-8bc6-4ef9-ac40-296c1d2d5372";
        public const string Deactivated = "ac7abcf3-8c50-454c-8096-66156e305a32";
        public const string UnhideProfile = "6ee63a04-d6e1-4f52-bb18-2deeafe196ef";
        public const string BlacklistProfile = "4d6db6e9-d912-4d29-bec9-cb47f2b58e05";
        public const string ApplyPremiumConfidential = "cb4798e3-03e1-449a-a70a-532b3d8497df";
        public const string ApplyBasicConfidential = "12eab9ab-d688-45d5-b9de-1839a702e011";
        public const string ApplyTestConfidential = "22837875-90aa-4117-9295-4cdf2c5ac809";
        public const string UpdateHiddenDuration = "8207a9bd-fd9b-41f0-b084-d3f48eb929ad";
        public const string RemoveBlacklist = "25f709cf-2879-4922-a968-8950dcc62c55";
        #endregion

        #region 
        public const string Addcandidatealert = "408ce3c4-7146-4d53-bc35-a658b4f67cd2";
        public const string Updatecandidatealert = "b5f78d6a-f68f-458f-948c-168a69330e48";

        #endregion

        public const string MagzineVisit = "597f4051-6860-4230-964e-a80e37a369ed";

        public const string PaymentVisit = "c6a23d19-12a0-4d12-a4c4-59f3b1dc5f1f";

        #region JC to FM
        public const string UpgradeJCtoFM = "60437b5d-6aa0-41d1-80be-d5382414db67";

        #endregion

        #region User Activation
        public const string ActivateProfile = "eff11d71-16ce-4795-a9e8-adbf0403197b";
        public const string SubscriptionStartDate = "073ae244-8ccb-4bd9-b001-18160aba632a";

        public const string SubscriptionEndDate = "b4e52878-4a04-4b3d-b1ef-258817c46ccb";
        public const string EditUserActivation = "1b851228-7eec-4c79-8b8e-56c4d73c3d67";
        public const string AutoActivation = "0f6664fa-bee7-43f4-954c-c79a03a4ebcb";
        public const string RemarksChanged = "cbddc9bc-b423-4062-bb91-3a6b58c3f83d";
        public const string ApplicationFormIdChanged = "0ed34481-d0a9-4f71-89ae-b665ad2d7991";
        public const string PaymentModeChanged = "d1b7098a-4b25-4b81-8814-3777687a29b8";
        public const string WithorWithoutOfferChanged = "22451319-388d-4129-ac88-addf8b82d7e2";
        public const string AmountChanged = "cb662400-9219-47b6-82c7-8c53091c6658";
        public const string TallyDateChanged = "a4fb7afb-92ab-4c9d-8f40-bd7752598cf0";
        public const string ReceiptNumberChanged = "2e33e5fb-a25a-4874-a874-b8351da30458";
        public const string MagazineStatusChanged = "1cc8d558-cdbc-4277-9818-6eefabc7133b";
        public const string MagazineEditionChanged = "4f02d38a-19a8-419d-ad02-2ef9c6fabfa2b";
        #endregion
        #region 
        public const string ConfidentialRequestAccept = "915adb73-8612-4084-b01a-d07e278ee479";
        public const string ConfidentialRequestDelete = "36876df7-1b36-4102-a2ac-d5b5ef4d62c1";
        public const string UnhideRequestAccept = "d801739f-6dc6-46bd-acbb-3cb403c7716e";
        public const string DeleteActivation = "54cb2197-68d3-4d97-9c7e-591aab593a89";
        public const string UnhideRequestDeleted = "3dd9e0c0-9640-4b37-a51c-6f7b1cc51727";
        public const string UnhideLogDeleted = "aef1b53b-6f81-4dfd-b320-75d5b8118be0";
        public const string ConfidentialLogDeleted = "138d1937-5423-45e5-aaa7-a5f0f31b74c8";
        public const string DeleteAutoActivation = "f749468a-850e-4b4b-b248-4487859e3f97";
        #endregion

        #region Chat
        public const string ChatBlocked = "03354f1a-a6b1-4c0a-acd2-27afd06e9547";
        public const string ChatUnblocked = "d40afbd0-1cc5-4f4c-ba98-c805d0b42ac1";
        public const string ChangeOnlineStatus = "7c4f7522-a93a-49e6-9926-18d7a4b97bd4";
        #endregion

        #region Photo Updated
        public const string ProfilePhotoUpdated = "35f36483-79f9-47b3-8d08-f18f636b6e58";
        public const string AlbumPhotoUpdated = "c9527f11-c97e-481f-97e1-0b4c2486c47c";
        public const string FamilyPhotoUpdated = "999db351-883d-465c-a7ac-ce30fa834c09";
        #endregion
    }
}