namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ValidationMessageConstant
    {
        #region User Info
        public const string UserId = "Please enter your User Id.";
        public const string Username = "Please enter Username";
        public const string Password = "Please enter password";
        public const string ConfirmPassword = "Please confirm password";
        public const string ResetPassword = "You have successfully updated your password";
        public const string MaximumReached = "The maximum token generation limit for one hour has been reached.";
        public const string ResetPasswordEmailSubject = "Password Reset Invitation sent Successfully";
        public const string InvalidToken = "Requested Token invalid";
        public const string ExpiredToken = "Token Expired";
        public const string ValidToken = "Token is Valid";
        public const string UsedPassword = "You recently used this password. \nPlease type in another one.";
        public const string SomthingWentWrong = "Something went wrong.";
        public const string NoToken = "Token not found.";
        public const string InvalidCandidateId = "Invalid CandidateId.";
        public const string UserNotFound = "User not found with the provided email or phone number.";
        public const string OldPassword = "Please choose a different password than the one you previously used.";
        public const string ChangePasswordSuccessMessage = "Your password has been successfully changed. Please log in again using your new password.";
        public const string PasswordNotMatch = "Passwords don't match.";
        public const string OldPasswordNotMatch = "Your current password entered is incorrect. Please try again.";
        public const string PasswordComparison = "Password and confirm password doesn't match.";
        public const string PasswordChangeMessage = "You have successfully changed the password.";
        public const string NotRegistered = "This account is not registered with Chavara Matrimony. Please try with another account.";
        public const string EnterNewPassword = "Enter new password";
        public const string EnterConfirmPassword = "Enter confirm password";
        public const string CandidateId = "Please enter your Candidate Id.";
        public const string RelationId = "Please enter your Relation Id.";
        public const string ChavaraId = "Please enter a valid Chavara ID.";
        public const string UnregisteredEmailId = "This Email Id is not registered with us, please check and retry.";
        public const string UnregisteredClientEmailId = "The Email that you have entered is not registered. Please ensure you have entered a valid and registered email address.";
        public const string UnregisteredClientEmailIdMsg = "The email id you have entered is not registered with us. Please enter a valid or registered email id.";
        public const string UnregisteredClientMobileNumber = "The mobile number that you have entered is not a registered number. Please ensure you have entered a valid and registered mobile number.";
        public const string UnregisteredClientMobileNumberMsg = "The mobile number you have entered is not registered with us. Please enter a valid or registered mobile number.";
        public const string ForgotPasswordUnregisteredMobileNumber = "The mobile number you have entered is not registered with us. Please enter a valid or registered mobile number.";
        public const string ForgotPasswordUnregisteredEmailId = "The email id you have entered is not registered with us. Please enter a valid or registered email id.";
        public const string LoginSuccess = "Login successful";
        public const string LogoutSuccess = "You have successfully logged out.";
        public const string IncorrectEmailOrPassword = "Invalid Email Id or Password.";
        public const string IncorrectUserIdOrPassword = "Invalid user Id or Password.";
        public const string OtpLimitExceeded = "OTP limit exceeded please retry after 1 Hour";
        public const string OtpLimitExceededInCandidateVerification = "Maximum resend attempts exceeded. Please skip and continue to next step.";
        public const string PasswordResetLimitExceeded = "Password reset limit exceeded.\nPlease retry after 1 hour.";
        public const string PhoneNumberNotRegistered = "This phone number is not registered with us.";
        public const string EmailIdNotRegistered = "This Email ID is not registered with us.";
        public const string ProvideValidLoginDetails = "Please provide the valid login details.";
        public const string OtpLimitExceededInCandidateVerificationforcommon = "Maximum resend attempts exceeded.";
        #endregion

        #region  Primary Information
        public const string FullName = "Please enter the full name.";
        public const string RecipientName = "Please enter the recipient name.";
        public const string SendertName = "Please enter the sender name.";
        public const string Gender = "Please select the gender.";
        public const string NoGender = "Gender not found.";
        public const string DOB = "Please enter the date of birth.";
        public const string Height = "Please select the height.";
        public const string Weight = "Please select the weight.";
        public const string Complexion = "Please select the complexion.";
        public const string NoComplexion = "Complexion does not exist";
        public const string NoBranches = "Branches does not exist";
        public const string BodyType = "Please select the body type";
        public const string NoBodyType = "Body type does not exist.";
        public const string NoBloodGroup = "Blood group  does not exist.";
        public const string BloodGroup = "Please select the blood group.";
        public const string Disability = "Please specify the differently abled category.";
        public const string DisabilityFormat = "Sorry, Invalid format. Only alphabets and  symbols like )‘ .( are  allowed.";
        public const string SpecifyDisability = "Please specify the differently abled category.";
        public const string NoDisability = "Disability does not exist";
        public const string Unit = "Please select unit of measurement.";
        public const string WeightRange = "Enter weight between 40 to 140";
        public const string HeightRange = "Enter height between 134 to 213";
        public const string AgeRange = "Please select age between 18 and 71";
        public const string AgeLegalWarning = "Legal age warning";
        public const string AgeRangeMale = "Please select age between 21 and 71";
        public const string MaritalStatus = "Please select your maritalstatus.";
        public const string NoMaritalStatus = "Marital status does not exist.";
        public const string AgeLimitBelow = "Please enter age below 71.";
        public const string MaleAgeLimitAbove = " Sorry, age between 21 and 71 is only allowed. Please retry (For Male).";
        public const string FemaleAgeLimitAbove = " Sorry, age between 18 and 71 is only allowed. Please retry (For Female).";
        public const string AboutMe = "Allowed only Alphanumeric and Symbols ',&-/(.";
        public const string PasswordValidation = "Your password should contain 6-14 characters with a mix of letters, numerals & at least one symbol.";
        public const string Url = "Please enter valid url";
        public const string NoSpecialNeed = "Special need not found";
        public const string CandidateReg = "Candidate registered succesfully";
        public const string CandidateUpdated = "Candidate details updated succesfully";
        public const string NoLanguage = "Language not found";
        public const string DetailUpdate = "Profile details saved successfully";
        public const string PrimaryEducationAndFamilyInfoUpdated = "Updated candidate additional primary, education and family informations.";
        public const string SentRequest = "You have successfully sent the request.";
        public const string Submit = "You have successfully updated.";
        #endregion

        #region  Religious Information
        public const string Denomination = "Please select the denomination.";
        public const string NoDenomination = "Denomination does not exist.";
        public const string Diocese = "Please select the diocese.";
        public const string DioceseName = "Please enter the diocese name.";
        public const string NoDiocese = "Diocese not found.";
        public const string CandidateReligionUpdate = "Candidate religion details updated succesfully";

        #endregion

        #region  Education & Professional Information
        public const string NoEducation = "Education doesn't exist";
        public const string NoEducationCategory = "Education category doesn't exist";
        public const string NoProfession = "Profession doesn't exist";
        public const string NoIndustry = "Profession doesn't exist";
        public const string NoEducationAndProfession = "Education and Profession not available";
        public const string EducationalQualifications = "Please select all education qualifications.";
        public const string EducationInDetail = "Please select the education qualification.";
        public const string OccupationCategory = "Please select the occupation category.";
        public const string OccupationDetails = "Please enter the occupation details.";
        public const string Profession = "Please select the occupation category.";
        public const string ProfessionDetail = "Please enter the occupation detail";
        public const string EmployedCategory = "Please select the employment category.";
        public const string NoEmployedCategory = "Employment category does not exist.";
        public const string WorkingCountry = "Please select the working country.";
        public const string WorkingState = "Please select the working state";
        public const string WorkingDistrict = "Please select the working district.";
        public const string WorkingTownPlace = "Please select the working town/place.";
        public const string NoWorkingCountry = "Working country does not exist";
        public const string NoWorkingState = "Working state does not exist";
        public const string NoWorkingDistrict = "Working district does not exist";
        public const string NoWorkingTown = "Working town does not exist";
        public const string AnnualIncome = "Please select the annual income.";
        public const string NoAnnualIncome = "Annual income does not exist.";
        public const string EducationAndProfessionUpdated = "Candidate education and occupation details updated successfully";
        public const string UniquePriority = "Education priority should be unique";
        #endregion

        #region Family Information
        public const string FamilyStatus = "Please select the family status.";
        public const string NoFamilyStatus = "Family status does not exist.";
        public const string FatherName = "Please enter the father’s name.";
        public const string FatherHouseName = "Please enter the father’s house name.";
        public const string FatherNativePlace = "Please enter the father’s native place.";
        public const string MotherName = "Please enter the mother’s name.";
        public const string MotherHouseName = "Please enter the mother’s house name.";
        public const string MotherNativePlace = "Please enter the mother’s native name.";
        public const string NoCandidateFamily = "Candidate family not found.";
        public const string CandidateFamilyUpdate = "Candidate family details updated succesfully";
        #endregion

        #region Location Information
        public const string NativeCountry = "Please select the native country.";
        public const string NativeState = "Please select the native state.";
        public const string NativeDistrict = "Please select the native district.";
        public const string NativeTownPlace = "Please select the native town/place.";
        public const string NoNativeCountry = "Native country does not exist";
        public const string NoNativeState = "Native state does not exist";
        public const string NoNativeDistrict = "Native district does not exist";
        public const string NoNativeTown = "Native town/place does not exist";
        public const string ResidingCountry = "Please select the residing country.";
        public const string ResidentialStatus = "Please select the residential status.";
        public const string ResidentialIndiaStatus = "For residential country 'India', does not have any residential status.";
        public const string NoResidentCountry = "Residing country does not exist";
        public const string NoResidentialStatus = "Residential status does not exist.";
        public const string NoLocationData = "Location information not available";
        public const string AvailableFrom = "If from date is not selected after selecting to date - Please select 'From' Date";
        public const string AvailableTo = "If to date is not selected after selecting from date - Please select 'To' Date";
        public const string LocationDataUpdated = "Location information updated successfully";
        public const string AddedLocationAndContactInfo = "Location and contact information added successfully";
        #endregion

        #region Contact Information
        public const string LandlinePhoneNumber = "Please enter the valid landline number.";
        public const string STDCode = "Please enter the valid STD code.";
        public const string MobilePhoneNumber = "Please enter the valid mobile number.";
        public const string WhatsappNumber = "Please enter the valid contact number.";
        public const string PrimaryMobileNumber = "Please enter the valid mobile number.";
        public const string PrimaryMobileNumberCustodianName = "Please enter the primary mobile no. custodian name.";
        public const string PrimaryMobileNumberCustodianRelation = "Please enter the primary mobile no. custodian relation.";
        public const string SecondaryMobileNumber = "Please enter the valid mobile number.";
        public const string AddressLine1 = "Please enter the house name/building no./apartment no. etc.";
        public const string AddressLine2 = "Please enter the street address/area/road name etc.";
        public const string Country = "Please select the country.";
        public const string EnterCountry = "Please enter country name.";
        public const string State = "Please select the state.";
        public const string EnterState = "Please enter state name.";
        public const string DistrictCityTown = "Please select the district/city/town.";
        public const string EnterDistrictCityTown = "Please enter district/city/town name.";
        public const string PINZip = "Please enter a valid pincode.";
        public const string EmailID = "Please enter the valid email.";
        public const string EmailIDOrPhoneExists = "Email Id or phone number you entered is already registered";
        public const string NoEmailID = "Email Id not found.";
        public const string EmailIdUpdated = "Email Id updated successfully";
        public const string AlternativeEmailID = "Please enter the valid email.";
        public const string ReferencePersonMobNo = "Please enter the valid mobile number.";
        public const string MagazineSendingAddress = "Please enter the house name/building no./apartment no.";
        public const string CommunicationAddress = "Please enter the address";
        public const string PresentAddress = "Please enter the address";
        public const string NoCurrentContact = "Contact information not avaliable";
        public const string NoOfficeContact = "Office contact information not avaliable";
        public const string NoPrimaryContact = "Primary contact information not avaliable";
        public const string NoCommunicationAddress = "Communication address information not avaliable";
        public const string NoPresentAddress = "Present address information not avaliable";
        public const string NoCandidateContact = "Candidate contact informations not available";
        public const string ContactUpdated = "Candidate contact updated successfully";
        public const string NoCommunicationType = "Communication type not found";
        public const string CustodianName = "Please enter the Custodian Name";
        public const string CustodianRelation = "Please enter the Custodian Relation";
        public const string candidateNotFound = "Candidate not found.";
        public const string InvalidTypeCode = "Invalid TypeCode.";
        public const string mobileVerify = "Successfully Verified MobileNumber";
        public const string emailVerify = "Successfully Verified EmailId";
        public const string Failedverify = "Verify Failed";

        #endregion

        #region  Social Media Information
        public const string Youtube = "Please enter the valid youtube address.";
        public const string SiteBlog = "Please enter the valid site/blog address.";
        public const string CandidateSocialMediaUpdate = "Candidate social media information updated succesfully";
        #endregion

        #region Digital Magazine Data
        public const string NameInMagazine = "Please enter the full name.";
        public const string EducationInMagazine = "Please enter the education qualifications.";
        public const string OccupationInMagazine = "Please enter the occupation.";
        public const string WorkPlaceInMagazine = "Please enter the workplace.";
        public const string CandidateMagazineUpdate = "Magazine details updated succesfully";
        #endregion

        #region Profile Creation Details
        public const string ProfileCreatedBy = "Please specify who created the profile.";
        public const string CreatorName = "Please enter the profile creator name.";
        public const string ContactNumber = "Please enter the valid contact number.";
        public const string HowDidYouHearAboutUs = "Please select the source.";
        public const string SpecifyTheSource = "Please enter the source.";
        public const string NoSource = "Source not found.";
        public const string NoFilter = "Filter not found.";
        public const string NoCreator = "Creator type not found";
        public const string UpdateCandidateCreatorDetails = "Candidate creator details updated";
        public const string ProfileCreator = "Please select the profile creator.";
        #endregion

        #region  Hobbies
        public const string NoHobbies = "Hobbies not found";
        public const string NoHabits = "Habits not found";
        public const string NoHobbiesSelected = "Not selected any hobbies";
        public const string HobbiesNotExist = "Hobbies does not exist";
        public const string CandidateHobbiesDataUpdated = "Candidate hobbies and interest details updated successfully";
        #endregion
        #region  Habits
        public const string HabitsNotExist = "Habits does not exist";
        #endregion
        #region  Social Media Info
        public const string NoSocialMediaInfo = "Social Media Info not found";
        #endregion

        #region Regular expression validation messages
        public const string AlphabetsOnly = "Sorry, Invalid format. Only alphabets are  allowed.";
        public const string NumberOnly = "Allowed only numbers";
        public const string AlphabetsAndNumbers = "Sorry, invalid format. Only alphanumeric characters are allowed.";
        public const string AcceptAlphNumHyphen = "Sorry, invalid format. Only alphanumeric characters and hyphens are allowed.";
        public const string AllowedCharacterName = "Sorry, Invalid format. Only alphabets and  symbols like )‘ .( are  allowed.";
        public const string AllowedCharecterAddress = "Sorry, invalid format. Only alphanumeric characters and symbols like ,.()’# &-/ are allowed.";
        public const string AllowedCharacterForAboutFamily = "Sorry, Invalid format. Only alphanumeric characters and symbols except *#@;][<>\" are allowed.";
        public const string AllowedCharecterDifferentlyAbled = "Allowed only Alphanumeric characters and symbols except *#@;][<>\" are allowed";
        public const string AllowedCharacterForAboutMe = "Sorry, Invalid format. Alphanumeric characters and symbols except *#@;][<>\" are allowed.";
        public const string AllowedCharacterForFatherHouseName = "Allowed only Alphabets and Symbols ('.&-,).";
        public const string AllowedCharacterForParentNativePlace = "Allowed only Alphabets and Symbols ('.&-).";
        public const string AllowedCharacterForMotherHouseName = "Allowed only Alphabets and Symbols ('.&-).";
        public const string AllowedCharacterForParentProfeesion = "Allowed only Alphabets and Symbols ('.&-).";
        public const string AllowedCharacterForcandidateasset = "Allowed only Alphabets and Symbols  ,.()' &-/";
        // public const string AllowedCharecterForPreferedTime = "Allowed alpha-numeric characters with symbols “ ,.()’ &-";
        // public const string AllowedCharacterForMagazineData = "Allowed alpha-numeric and Symbols  ,.()'&-/";
        // public const string AllowedCharecterForDetails = "Allowed alpha-numeric characters with symbols “ ,.()’ &-";
        public const string AllowedCharecterForPreferedTime = "Sorry, invalid format. Only alphanumeric characters and symbols like ,.()’# &-/ are allowed.";
        public const string AllowedCharacterForMagazineData = "Sorry, invalid format. Only alphanumeric characters and symbols like ,.()’# &-/ are allowed.";
        public const string AllowedCharecterForDetails = "Sorry, invalid format. Only alphanumeric characters and symbols like ,.()’# &-/ are allowed.";
        public const string AllowedCharacterForSuccessStory = "Sorry, Invalid format. Special characters like (‘ .) are only allowed in this field.";
        public const string AllowedCharacterForSuccessStoryMessage = "Sorry, Invalid format. Only alphanumeric characters and symbols except *#@;][<>\" are allowed.";


        #endregion

        #region Charecter Limitation
        public const string MaximumCharecterLimit = "Maximum allowed characters is ";
        public const string MaximumCharecterLimitMagazineAddress = "Maximum allowed characters for magazine address is 40 ";
        public const string CharacterlengthForName = "Minimum  allowed characters is 2 and maximum 50 character ";
        public const string CharacterlengthForPhotoPassword = "Minimum  allowed characters is 2 and maximum 20 character ";
        public const string CharacterlengthForFamilyOccupation = "Minimum  allowed characters is 2 and maximum 50 character ";
        public const string AllowedCharacterlengthTwoHundred = "Maximum allowed characters is 200";
        public const string AllowedCharacterlengthFiveThousand = "Maximum allowed characters is 5000";
        public const string AllowedCharacterlengthFiveHundred = "Maximum allowed characters is 500";
        #endregion

        #region Other
        public const string NoCandidate = "Candidate does not exist.";
        public const string NoRelation = "Relation does not exist.";
        public const string NoMedia = "Media does not exist.";
        public const string NoUser = "User does not exist.";
        public const string NoBranch = "Branch does not exist.";
        public const string UserAdded = "User added successfully";
        public const string UserUpdated = "User updated successfully";
        public const string NoCandidateDisablity = "Candidate Disablity not found";
        public const string NoCandidateProfession = "Candidate profession does not exist";
        public const string NoCandidateEducation = "Candidate education does not exist";
        public const string NoCandidateEducationAndProfession = "Candidate education and profession does not exist";
        public const string BranchIdExist = "The Branch ID already exists. Please enter a new one";

        public const string ValidBranchId = "Please enter the correct Branch ID";

        public const string ValidBranchIdAvailable = "Branch Id available";

        public const string ValidChavaraId = "Please enter a valid Chavara ID";

        public const string NoSourceCandidate = "Source Candidate does not exist.";


        #endregion

        #region  Source
        public const string NoSourceCategory = "Please select any media.";
        #endregion

        #region  Partner preference
        public const string HeightRelation = "Sorry, Invalid height range. 'From' height should be less than to 'To' height";
        public const string AgeRelation = "Sorry, Invalid age range. 'From' age should be less than to 'To' age";
        public const string PreferenceUpdated = "Partner preference updated successfully";
        #endregion

        #region Registration
        public const string NoReligion = "Please select the denomination.";
        public const string Religion = "Please select Religion";
        public const string Subcaste = "Please select Subcaste";
        public const string NoCaste = "Caste not found";
        public const string NoSubCaste = "Subcaste not found";
        public const string NoCasteOrDenomination = "Caste or subcaste not found";
        #endregion

        #region Location
        public const string NoCountry = "Country does not exist.";
        public const string NoState = "State does not exist.";
        public const string NoDistrict = "District does not exist.";
        public const string NoTown = "Town does not exist.";
        public const string NoNativePlace = "Please enter the native place";
        #endregion


        #region  Candidate Activit Log
        public const string AddCandidateActivity = "Candidate ActivityLog Added.";
        public const string WentWrong = "Something Went Wrong";

        #endregion

        #region Type checking message

        public const string FmChekingMsg = "Profile details saved & Profile type successfully changed to FM";

        #endregion

        #region Candidate Photos
        public const string CandidatePhotoUploaded = "Candidate photo uploaded";
        public const string ProfilePhotoSet = "Profile photo set successfully.";
        public const string NoPhoto = "Candidate photo not found.";
        public const string NoPhotoType = "Photo type not found.";
        public const string PhotoType = "Select Photo type.";
        public const string FailedToUpload = "Failed to upload the photo.";
        public const string MaximumSizeExceeded = "Please choose photo less than 30 MB.";
        public const string UnsupportedPhotoFormat = "Your selected photo format is unsupported, please use JPG, JPEG, PNG, GIF format.";
        public const string UnsupportedIdProofFormat = "Your selected ID Proof format is unsupported, please use JPG, JPEG, PNG, GIF, PDF format.";
        public const string SmallPhoto = "Your uploaded photo is too small";
        public const string ReasonForRejection = "Please enter the reason for rejecting";
        public const string PhotoRejected = "You have successfully rejected the photo.";
        public const string PhotoAccepted = "You have successfully accepted the photo.";
        public const string PhotoDeleted = "You have successfully deleted the photo.";
        public const string PhotoArchived = "You have successfully archived the photo.";
        public const string PhotoRestored = "You have successfully restored the photo.";
        public const string AlbumPhotoSwapped = "Your album photo swapped successfully.";
        public const string FamilyPhotoSwapped = "Your family photo swapped successfully.";
        public const string SwapNotAvailable = "Swap not available for this photo type.";
        public const string PhotoPassword = "Enter photo password.";
        public const string NoPhotoPrivacyPolicyType = "Photo privacy policy type not found.";
        public const string UpdatedPhotoPrivacy = "Photo privacy policy type updated.";
        #endregion

        #region OTP
        public const string OtpSend = "OTP sent successfully.";
        public const string OtpSendToEmail = "The OTP has been successfully sent to your mail.";
        public const string OtpReSendToEmail = "The OTP has been successfully resent to your mail.";
        public const string OtpSendToMobile = "The OTP has been successfully sent to your mobile.";
        public const string OtpReSendToMobile = "The OTP has been successfully resent to your mobile.";
        public const string SendOnlyToIndianNumber = "OTP will be sent to an Indian number only.";
        public const string NoOtp = "OTP not found.";
        public const string OtpVerified = "You have successfully completed the OTP verification.";
        public const string IncorrectOtp = "OTP is not valid, please check and retry.";
        public const string ExpiredOtp = "OTP is expired, please select 'Resend OTP' to get new OTP.";
        public const string ExpiredOtpMobile = "OTP expired. Tap resend OTP to get new one.";
        public const string IncorrectOtpLimitExceeded = "Maximum OTP attempts exceeded. Please select 'Resend OTP' to get new OTP.";
        public const string IncorrectOtpLimitExceededMobile = "Maximum attempts reached. Tap Resend OTP.";
        public const string InvalidVerificationType = "Invalid verification type.";
        public const string EnterOtp = "Please enter OTP.";

        #endregion

        #region Guidelines
        public const string NoGuideline = "No guidelines matching the requested type were found.";
        #endregion

        #region IdProof
        public const string NoDocumentType = "Document type not found.";
        public const string FailedToUploadIdProof = "Failed to upload id proof.";
        public const string IdProofUploaded = "Id proof uploaded successfully.";
        public const string IdProofTypeAndNumberUpdated = "Id proof document type and number updated successfully.";
        public const string CandidateDataInIdProofUpdated = "Candidate data in Id Proof is updated successfully.";
        public const string NoIdProof = "Id proof not found.";
        public const string NoIdProofDocument = "Id proof document not found.";
        public const string IdProofDocumentMaxNumber = "Only 2 documents are allowed as id proof.";
        public const string AadarCardNumber = "Please enter valid aadhar card number.";
        public const string MaximumIdProofSizeExceeded = "Please choose document less than 30 MB.";
        public const string IdProofDeleted = "Id proof deleted successfully.";
        public const string IdProofAccepted = "Id proof accepted successfully.";
        public const string IdProofRejected = "Id proof rejected successfully.";
        public const string IdProofDocumentDeleted = "Id proof Document deleted successfully.";
        #endregion

        #region Subscription
        public const string NoCandidateSubscription = "Candidate subscription not found";
        public const string NoCoupons = "No coupons found.";
        #endregion

        #region  CandidateAvailability
        public const string FromDateTodate = "Sorry, invalid date range. 'From date' should be prior to 'To date'.";
        public const string ToDateTodaydate = "Sorry, Please enter a date after today's date.";
        public const string ToDateNull = "Please select 'To date'.";
        public const string FromDateNull = "Please select 'From date.";

        #endregion

        #region  Payment
        public const string NoBankDetails = "Bank details not fount.";
        public const string BankDetailsSend = "Bank details sent successfully.";

        #endregion

        #region  Message
        public const string MessageGroup = "Please enter a valid message group.";
        public const string MessageCategory = "Please enter a valid message category.";
        public const string NoMessage = "Messages not found.";
        public const string NoMessageType = "Please enter a valid message type.";
        public const string SameGender = "Message can't sent to same gender.";
        public const string MessageSended = "Message already sended by candidate or Received from receiver side.";
        public const string MessageSendSuccessfully = "You have successfully sent the interest message.";
        public const string PhotoUploadRequestSendSuccessfully = "You have successfully sent the photo upload request.";
        public const string PhotoViewRequestSendSuccessfully = "You have successfully sent the photo view request.";
        public const string AlbumPhotoViewRequestSendSuccessfully = "You have successfully sent the album photo view request.";
        public const string FamilyPhotoViewRequestSendSuccessfully = "You have successfully sent the family photo view request.";
        public const string ChatRequestSendSuccessfully = "You have successfully sent the Chat request.";
        public const string MessageAcceptedSuccessfully = "Message accepted successfully.";
        public const string ChatRequestAcceptedSuccessfully = "Chat request approved  successfully.";
        public const string PhotoRequestAcceptedSuccessfully = "Photo request accepted successfully.";
        public const string MessageRespondedSuccessfully = "Response sent successfully.";
        public const string MessageDeclinedSuccessfully = "Message declined successfully.";
        public const string ChatRequestDeclinedSuccessfully = "Chat request declined successfully.";
        public const string PhotoRequestDeclinedSuccessfully = "Photo request declined successfully.";
        public const string MessageAlreadyResponded = "Dear candidate, you already responded to this message.";
        public const string MessagesCleared = "Candidate messages cleared";
        public const string MessageSentLimitExceeded = "You have reached the maximum number of messages allowed for today. Unfortunately, you won't be able to send any more messages until tomorrow.";
        public const string NotAllowedToSendMessage = "Sorry! Your interest message cannot be sent as your Free Membership is undergoing verification.";
        public const string NotAllowedToSendMessageDescription = "Your profile will be activated within 24 working hours upon successful verification through the provided telephone number/s. You'll receive an activation email once the process is complete. For instant activation, Upgrade Now.";
        public const string RecieverCandidateId = "Enter reciever candidate Id";
        public const string MessageTypeCode = "Enter message type code";

        public const string AlreadySentInterestMessage = $"You have already sent an interest message to this candidate on {ReplacingConstant.Date}., so you can send message again on or after {ReplacingConstant.DateAfter}.";
        public const string AlreadySentAndCancelled = $"You have already sent an interest message to this candidate on {ReplacingConstant.Date} and then cancelled it. Are you sure, you wish to send again?";
        public const string AlreadySentMessageDescription = "You can only resend the message after 30 days of the interest message being sent, if they have not responded within that time period.";
        public const string AlreadySentAndExpired = $"You have already sent an interest message to this candidate on {ReplacingConstant.Date}.  \nAre you sure, you wish to send again?";
        public const string AlreadyRecievedInterestMessage = $"You have already received an interest message from this  member on {ReplacingConstant.Date}. But you haven’t responded to it.";
        public const string AlreadyRecievedInterestMessageAndExpired = $"You have already received an interest message from this candidate on {ReplacingConstant.Date}, but it has expired. Do you wish to send an interest message now?";
        public const string AlreadyRecievedInterestMessageAndTrashed = $"You have already received an interest message from this member on {ReplacingConstant.Date}.  But you have trashed it on {ReplacingConstant.DoneDate}.  \nYou can send message to this candidate on or after {ReplacingConstant.DateAfter}.";
        public const string AlreadyRecievedInterestMessageAndDeleted = $"You have received an interest message from this candidate on {ReplacingConstant.Date}. ";
        public const string AlreadyRecievedInterestMessageAndDeletedDescription = $"You have deleted the received message on {ReplacingConstant.Date}, So you can’t respond now. You can send message to this candidate on or after {ReplacingConstant.DateAfter}.";
        public const string AlreadyRecievedInterestMessageAndDeletedDescriptionAndExpired = $"You have deleted the received message on {ReplacingConstant.Date}. Do you wish to send an interest message now?";
        public const string AlreadySentAndDeclined = "This candidate has declined the interest message you previously sent. So you can't send it again.";
        public const string AlreadySentAndAccepted = $"This candidate has accepted the interest message you previously sent on {ReplacingConstant.Date}. So you can't send it again. ";
        public const string AlreadyReceivedAndAccepted = "You have already accepted the interest message received from this candidate.";
        public const string NotAbleToAcceptOrDecline = "You are not able to accept/decline message.";
        public const string AlreadyReceivedAndDeclined = $"You have declined the interest message received from this candidate on {ReplacingConstant.Date}, so you can’t send a message now. You can cancel the declined message and accept now. ";
        public const string MessageTrashed = "Interest message trashed successfully.";
        public const string SuccessfullyRestored = "Successfully Restored.";
        public const string ChatRequestTrashed = "Chat request trashed successfully.";
        public const string PhotoRequestTrashed = $"{ReplacingConstant.Count} Moved to Trash.";
        public const string MessageDeleted = "Message deleted successfully.";
        public const string PhotoRequestsDeleted = "Photo requests deleted successfully.";
        public const string ChatRequestDeleted = "Chat requests deleted successfully.";
        public const string MessageStarred = "Candidate message starred successfully.";
        public const string AlreadyRespondLater = "Message already added to respond later.";
        public const string NotAbleToRespondLater = "You have already responded.";
        public const string AddedToRespondLater = "You have successfully done Respond Later.";
        public const string NotAbleToCancel = "You are not able to cancel the action";
        public const string AlreadyCancelled = "You are already cancelled the action.";
        public const string MessageUnstarred = "Candidate message unstarred successfully.";
        public const string NotAbleToReply = "You are not able to respond.";
        public const string ReplyMessageSent = "Reply sent.";
        public const string AlreadySendPhotoUploadRequest = $"You have already sent a photo upload request to this candidate on {ReplacingConstant.Date}.";
        public const string AlreadySendPhotoUploadRequestAndExpired = $"You have already sent a photo upload request to this candidate on {ReplacingConstant.Date}. Are you sure, you wish to send again?";
        public const string AlreadySendPhotoViewRequest = $"You have already sent a photo view request to this candidate on {ReplacingConstant.Date}.";
        public const string AlreadySendPhotoViewRequestAndExpired = $"You have already sent a photo upload request to this candidate on {ReplacingConstant.Date}. Are you sure, you wish to send again?";
        public const string AlreadySendAlbumPhotoViewRequest = $"You have already sent album photo upload request to this candidate on {ReplacingConstant.Date}.";
        public const string AlreadySendAlbumPhotoViewRequestAndExpired = $"You have already sent album photo upload request to this candidate on {ReplacingConstant.Date}. Are you sure, you wish to send again?";
        public const string AlreadySendFamilyPhotoViewRequest = $"You have already sent family photo upload request to this candidate on {ReplacingConstant.Date}.";
        public const string AlreadySendFamilyPhotoViewRequestAndExpired = $"You have already sent family photo upload request to this candidate on {ReplacingConstant.Date}. Are you sure, you wish to send again?";
        public const string AlreadySendChatRequest = $"You have already sent a chat request to this candidate on {ReplacingConstant.Date}.";
        public const string AlreadySendChatRequestAndExpired = $"You have already sent a chat request to this candidate on {ReplacingConstant.Date}. Are you sure, you wish to send again ?";
        public const string AlreadyRecievedChatRequest = $"You have already received a chat request from this candidate on {ReplacingConstant.Date}.";
        public const string AlreadyRecievedChatRequestAndExpired = $"You have already received a chat request from this candidate on {ReplacingConstant.Date}, but it has expired. Do you wish to send an chat request now?";
        public const string AlreadySentAndAcceptedChatRequest = $"This candidate has accepted the chat request you previously sent on {ReplacingConstant.Date}. So you can't send it again.";
        public const string AlreadyReceivedAndAcceptedChatRequest = "You have already accepted the chat request received from this candidate.";
        public const string AlreadySentAndDeclinedChatRequest = $"This candidate has declined the chat request you previously sent on {ReplacingConstant.Date}. So you can't send it again.";
        public const string AlreadyReceivedAndDeclinedChatRequest = "You have already declined the chat request received from this candidate.";

        #endregion

        #region  AppConfiguration

        public const string MessageNoAppLaunchConfigration = "Application Launch Configuration does not exist";
        #endregion

        #region Candidate views
        public const string NoProfileViews = "Candidate profile views not found.";
        public const string NoContactViews = "Candidate contact views not found.";
        public const string NoProfileOrContactViews = "Candidate profile/contact views not found.";
        public const string ClearedProfileOrContactViews = "Candidate profile/contact views cleared.";
        #endregion

        #region Search

        public const string NoProfile = "No profile found";

        #endregion

        #region Number
        public const string NumberOfChildren = "2";
        public const string SpecifySpecialNeedCharLength = "50";
        public const string DisabilityDescriptionCharLength = "500";
        public const string AboutMeCharLength = "5000";
        public const string AssetDetailsCharLength = "500";
        public const string AboutFamilyCharLength = "5000";
        #endregion

        #region Wishlist
        public const string AddWishlist = "You have successfully saved the wishlist";
        public const string DeletedWishlist = "You have successfully deleted the wishlist";

        #endregion

        #region Response Message
        public const string ResponseOk = "OK";
        #endregion

        #region Wishlist
        public const string NoWishlistName = "Please enter the wishlist name.";
        #endregion

        #region Support Request 
        public const string NoSupportRequestCategories = "Support Request Categories does not exist";
        public const string NoSupportRequestCategory = "Support Request Category does not exist";
        public const string MaximumCharecterLimitSuportRequestMessage = "Maximum allowed characters for Support Request Message is 1000";
        public const string AllowedCharacterForSupportRequestMessage = "Sorry, Invalid format. Only alphanumeric characters and symbols except *#@;][<>\" are allowed.";
        public const string PhoneNUmberValidation = "Phone number is mandatory.  If number is not given Email should not sent.";
        #endregion

        #region CandidateAction
        public const string ReportMisuseSucessMessage = "You have successfully reported the concern.";
        public const string ReportReason = "Please enter reason for report misuse.";
        public const string ProfileForwardedSuccess = "Profile forwarded successfully.";
        public const string NotAllowedToShortlist = "Sorry! You cannot shortlist the profile as your Free Membership is undergoing verification.";
        public const string NotAllowedToBlock = "Sorry! You cannot block the profile as your Free Membership is undergoing verification.";
        #endregion

        #region  successstory
        public const string NoSuccessStories = "Success stories are not found";
        public const string NoSuccessStory = "Success Story Data not available";
        public const string SuccessStorySuccessResult = "You have successfully saved the SuccessStory.We Will review And Publish it on Our website and app ";
        public const string SuccesstoryNotSave = "SuccessStory not Saved";
        public const string SuccessStorySuccessCRM = "You have successfully submitted the success story.";

        #endregion

        #region testimonial
        public const string NoTestimonial = "Testimonials are not found";
        #endregion

        #region AppDownload
        public const string NoAppDownloadQRImage = "There is no QR Image";
        public const string SMSSendSuccess = "The app download link has been successfully sent to your mobile device.";
        public const string SMSSendFailed = "Please enter a valid mobile number";
        #endregion

        #region Dashboard
        public const string FMDashboardTitle = "Your free membership is under verification.";
        public const string FMDashboardDescription = "The activation of your profile will be done within 24 working hours provided.";
        public const string FMDashboardMessage = "Immediate Activation";
        public const string ONDashboardTitle = null;
        public const string ONDashboardDescription = "Upgrade your free membership today and avail the benefits of Premium Membership.";
        public const string ONDashboardMessage = $"Expire within {ReplacingConstant.Count} days.";

        public const string PaidExpireSoonDashboardTitle = null;
        public const string PaidExpireSoonDashboardDescription = "Your premium membership with Chavaramatrimony.com is expiring soon. \nRe-register your membership today and avail the benefits of Premium Membership.";
        public const string ExpireWithinDays = $"Expire within {ReplacingConstant.Count} days.";
        public const string ExpireToday = $"Expire today";

        public const string GracePeriodDashboardTitle = "Your validity is extended.";
        public const string GracePeriodDashboardDescription = $"Your profile validity will be extended for {ReplacingConstant.Count} more days with limited access. You can re-register your profile at any time during this period and avail the benefits of Premium Membership.";

        public const string PaidExpiredDashboardTitle = null;
        public const string PaidExpiredDashboardDescription = "Your Premium Membership with ChavaraMatrimony.com is expired. Re-register your membership today and avail the benefits of Premium Membership.";
        public const string ExpiredDashboardMessage = $"Membership Expired.";
        #endregion

        #region  Switch candidate
        public const string SwitchCandidateSuccessfully = "Switched candidate successfully.";
        #endregion

        #region  Comment
        public const string Comment = "Please enter the full omment.";

        public const string AddComment = "Comment added successfully";

        #endregion



        #region CelestialMatrimony
        public const string NoCelestialMatrimony = "There is no Celestial Matrimony details";
        #endregion


        #region  ProfileFilter
        public const string ProfileFilterSaved = "Successfully changed the profile visibility.";
        public const string ConfidentialRequest = "You have successfully sent the request.";
        public const string ProfileFilterChanged = "You have successfully changed the profile visibility.";
        #endregion


        #region  Search visibility Filter

        public const string SaveAgeFilter = "Successfully changed the search visibility filter.";


        #endregion

        public const string EnterSubscriptionType = "Please enter the subscription type.";

        #region  ProfileDeactivate
        public const string ProfileDeactivate = "You have successfully deactivated this profile.";

        public const string ProfileDelete = "You have successfully deleted your profile.";

        #endregion

        #region  ProfileDeactivate
        public const string CommentAddded = "Successfully fetched user activity.";
        public const string DeactivateReason = "Please select deactivate reason";

        public const string InformedBy = "Please select informed by";

        public const string ModeOfRequest = "Please select mode of request";
        public const string RequestBranchName = "Please select request branch executive name";
        #endregion
        #region  ProfileUnHide

        public const string NoHiddenCandidate = "Candidate has not applied hidden filter.";
        public const string UnHideCandidate = "You have successfully unhid the profile.";
        public const string RequestedBy = "Please select requested by";
        public const string AlreadyRequestForUnhide = "Candidate is already requested for unhide.";
        public const string Duration = "Please select hide duration";
        public const string Hidereason = "Please select reason for hiding your profile";




        #endregion

        #region  ProfileAttribute
        public const string AlreadyAppliedAttributeFilter = "Candidate already applied attribute filter.";
        public const string AttributeFilter = "Please select confidential type";
        public const string ConfidentialRequestPending = "Confidential request already pending.";
        public const string NotConfidential = "This Prfile is not confidential.";

        #endregion

        #region Candidate AlertsF
        public const string NoAlert = "Candidate alert not found.";
        public const string AlertUpdate = "Successfully modified the alert settings.";

        #endregion

        #region  ProfileBlacklist

        public const string AlreadyBlackList = "Candidate is already a blacklisted member.";
        public const string NotBlacklisted = "Candidate is not a blacklisted member.";
        public const string Blacklist = "You have successfully blacklisted this profile.";
        public const string RemovedfromBlackList = "You have successfully removed this profile from blacklist.";


        #endregion

        #region 

        public const string AdvertisementImpression = "Successfully updated Impression count.";
        public const string AdvertisementClick = "Successfully updated Click count.";
        public const string NoAdvertisement = "Advertisement not found.";
        public const string NopageHash = "PageHash not found.";
        public const string NoAdvertisementId = "Advertisement not found";

        #endregion

        #region 

        public const string SubscriptionStartDateChangeComment = $"Added date Changed by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch from {ReplacingConstant.SubscriptionStartDate} to {ReplacingConstant.NewSubscriptionStartDate}";
        public const string SubscriptionEndDateChangeComment = $"Expiry date Changed by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch from {ReplacingConstant.SubscriptionEndDateDate} to {ReplacingConstant.NewSubscriptionEndDate}";

        #endregion

        #region  ProfileActivate
        public const string Amount = "Please enter the amount";
        public const string ReVerifyAmount = "Please re-verify the amount";
        #endregion

        #region Subscription Date Validation
        public const string SubscriptiondateGreaterThanFutureDate = "Subscription Date should be less than Future Date";
        public const string SubscriptiondateGreaterThanExpiryDate = "Subscription Date should be less than Expiry Date";
        #endregion

        #region 
        public const string ConfidentialRequestComment = $"Request for changing profile visibility to {ReplacingConstant.ProfileVisibility} sent by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string RemoveAttributeComment = $"{ReplacingConstant.Attribute} is removed by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string DeleteProfileComment = $"Profile deleted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.Reason: {ReplacingConstant.Reason}";

        public const string RemovedfromBlackListComment = $"Profile removed from blacklist by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch. Reason: {ReplacingConstant.Reason}";

        public const string ReactivateProfileComment = $"Profile is Reactivated from Invalid Membership to {ReplacingConstant.UserType} Membership by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch";

        #endregion

        #region 
        public const string DeviceInfoAdded = "Device Information Added";
        public const string DeviceInfoUpdated = "Device Information Updated";
        #endregion
        #region 
        public const string ChangeRequestDeleteSuccess = "You have successfully deleted profile updation request.";
        public const string ChangeRequestFailure = "Failed to delete the profile update request. Please try again later.";
        public const string ChangeRequestApproved = "You have successfully acccepted the profile updation request.";
        public const string ChangeRequestRejectd = "You have successfully rejected the profile updation request.";
        public const string ChangeRequestNotFound = "Change request not found. Please try again later.";

        #endregion
        #region
        public const string ConfidentialRequestAcceptComment = $"Confidential profile request accepted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string ConfidentialRequestDeleteComment = $"Confidential profile request deleted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string UnhideRequestAcceptComment = $"Profile unhide request accepted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string UnhideRequestDeleteComment = $"Unhide request deleted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string UnhideLogDeleteComment = $"Unhide log deleted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string ConfidentialLogDeleteComment = $"Confidential profile log deleted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";

        #endregion

        #region Photo CRM
        public const string PhotoAcceptAdmin = $"{ReplacingConstant.PhotoType} accepted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        public const string PhotoDeleteAdmin = $"{ReplacingConstant.PhotoType} deleted by {ReplacingConstant.UserName}, {ReplacingConstant.UserBranch} Branch.";
        #endregion
    }
}