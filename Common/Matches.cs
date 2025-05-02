using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Constants;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class Matches : IMatches
    {
        private readonly FinderSchedulerDbContext _context;
        private readonly FinderSetting _setting;
        private readonly ILogger _logger;

        public Matches(FinderSchedulerDbContext context, FinderSetting setting, ILoggerFactory loggerFactory)
        {
            _context = context;
            _setting = setting;
            _logger = loggerFactory.CreateLogger<Matches>();
        }
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
        public async Task<List<CandidateDetailsDTO>> GetCandidateDetails(long[] candidateId, long loginCandidateId, string[] membershipCode)
        {

            var result = await _context.candidates.Include(e => e.MaritalStatus).Include(e => e.Gender).Where(e => candidateId.Contains(e.Id))
           .GroupJoin(
               _context.candidateFamilies,
               candidate => candidate.Id,
               family => family.Candidate.Id,
               (candidate, family) => new
               {
                   candidate = candidate,
                   family = family
               }
           )
           .SelectMany(
               candidateFamily => candidateFamily.family.DefaultIfEmpty(),
               (candidate, family) => new
               {
                   candidate = candidate.candidate,
                   family = family
               }
           )
           .GroupJoin(
               _context.candidateProfessions.Include(e => e.WorkingCountry).Include(e => e.WorkingDistrict)
               .Include(e => e.WorkingTown).Include(e => e.WorkingState),
               candidate => candidate.candidate.Id,
               profession => profession.Candidate.Id,
               (candidate, candidateProfession) => new
               {
                   candidate = candidate.candidate,
                   family = candidate.family,
                   candidateProfession = candidateProfession
               }
           ).SelectMany(
               candidateProfession => candidateProfession.candidateProfession.DefaultIfEmpty(),
               (candidate, profession) => new
               {
                   candidate = candidate.candidate,
                   family = candidate.family,
                   profession = profession
               }
           ).GroupJoin(_context.candidateSubscriptions.Include(e => e.Subscription).Where(e => e.IsSubscriptionActive),
           candidate => candidate.candidate.Id,
           candidateSubscription => candidateSubscription.Candidate.Id,
           (candidate, candidateSubscription) => new
           {
               candidate = candidate.candidate,
               family = candidate.family,
               candidateProfession = candidate.profession,
               candidateSubscription = candidateSubscription
           }
           ).SelectMany(candidateSubscription => candidateSubscription.candidateSubscription.DefaultIfEmpty(),
           (candidate, subcription) => new
           {
               candidate = candidate.candidate,
               family = candidate.family,
               profession = candidate.candidateProfession,
               subscription = subcription
           }
           )
           .Select(e => new CandidateDetailsDTO
           {
               Id = e.candidate.Id,
               Name = e.candidate.Name,
               gender = e.candidate.Gender,
               Education = e.candidate.EducationDetails,
               Occupation = e.profession.Details,
               ProfileId = e.candidate.ProfileId,
               ReligionTreePath = e.candidate.ReligionTreePath,
               FatherName = e.family.FatherName,
               Workplace = GetWorkplaceV2(e.profession.WorkingCountry.Name, e.profession.WorkingState.Name, e.profession.WorkingDistrict.Name, e.profession.WorkingTown.Name),
               Age = e.candidate.DOB != null ? CalculateAge(e.candidate.DOB) : null,
               Height = e.candidate.HeightInCentimeter + "CM",
               MaritalStatus = e.candidate.MaritalStatus.Name,
               candidateSubscription = e.subscription
           }).ToListAsync();

            var response = result.Select(e => new CandidateDetailsDTO
            {
                Id = e.Id,
                Name = IsNameVisible(membershipCode, ProductConstant.ClientAppProductCategoryCode, e.Name),// e.Name,
                gender = e.gender,
                Education = e.Education,
                Occupation = e.Occupation,
                ProfileId = e.ProfileId,
                FatherName = e.FatherName,
                Workplace = e.Workplace,
                Denomination = e.ReligionTreePath != null ? GetReligion(e.ReligionTreePath) : string.Empty,
                Age = e.Age,
                ContactDetails = GetCandidateContactDetail(e.Id),
                Height = e.Height,
                MaritalStatus = e.MaritalStatus,
                IsCelestial = CheckCelestial(e.Id),
                ImageUrl = GetPhotoHideSender(e.Id, loginCandidateId, e.gender),
                candidateSubscription = e.candidateSubscription
            }).ToList();

            return response;
        }
        public string IsNameVisible(string subscriptionCode, string productCategoryCode, string name)
        {
            if (productCategoryCode == ProductConstant.BusinessAppProductCategoryCode ||
                productCategoryCode == ProductConstant.BusinessAppProductCode)
            {
                return name;
            }
            bool status = _setting.IS_NAME_VISIBLE_FOR_FREE ||
                          !SubscriptionConstant.NameVisibilityRestrictedSubscriptionCodes.Contains(subscriptionCode);

            return status ? null : name;
        }
        public string IsNameVisible(string[] subscriptionCodes, string productCategoryCode, string name)
        {
            if (productCategoryCode == ProductConstant.BusinessAppProductCategoryCode ||
                productCategoryCode == ProductConstant.BusinessAppProductCode)
            {
                return name;
            }

            bool isNameVisible = _setting.IS_NAME_VISIBLE_FOR_FREE ||
                                 !subscriptionCodes.Any(code => SubscriptionConstant.NameVisibilityRestrictedSubscriptionCodes.Contains(code));

            return isNameVisible ? name : null;
        }
        public string GetPhotoHideSender(long candidateId, long loginId, GenderModel gender)
        {
            var sql = "SELECT photo_hide_sender(@CandidateId, @LoginId)";
            var parameters = new[]
            {
                new Npgsql.NpgsqlParameter("CandidateId", candidateId),
                new Npgsql.NpgsqlParameter("LoginId", loginId)
            };

            var res = _context.PhotoResponseUrl.FromSqlRaw(sql, parameters).FirstOrDefault();
            if (res.photo_hide_sender == null) return GetProfilePhotoAvatarPath(gender.Code);
            return _setting.DISPLAY_PHOTO_BASE_URL + res.photo_hide_sender;
        }

        public async Task<List<CandidateDetailsDTO>> CandidateSearchByMyMatchV2(long candidateId, long genderId, String[] membershipCode)
        {
            try
            {
                var candidatesfinalresult = await CandidateSearchByMyMatchQueryBuilder(candidateId, genderId);

                var result = await candidatesfinalresult.Take(10).ToListAsync();

                List<long> dataArray = result.Select(item => item.Id).ToList();
                if (dataArray.Count > 0)
                {
                    long[] dataArrayAsArray = dataArray.ToArray();

                    var final = await GetCandidateDetails(dataArrayAsArray, candidateId, membershipCode);
                    var response = final.Adapt<List<CandidateDetailsDTO>>();
                    return response;
                }
                else
                {
                    return new List<CandidateDetailsDTO>();

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return new List<CandidateDetailsDTO>(); ;
            }
        }
        public string GetProfilePhotoAvatarPath(string GenderCode)
        {
            string noImageUrl = GenderCode == GenderConstant.MaleCode ? PhotoConstant.NoImageMaleURL : PhotoConstant.NoImageFemaleURL;
            return $"{_setting.FINDER_PHOTOS_BASE_URL}{_setting.FINDER_IMAGE_ASSETS_URL}{noImageUrl}";
        }
        public string GetProfilePhotoAvatarPath(CandidateModel candidate)
        {
            string noImageUrl = candidate.Gender.Code == GenderConstant.MaleCode ? PhotoConstant.NoImageMaleURL : PhotoConstant.NoImageFemaleURL;
            return $"{_setting.FINDER_PHOTOS_BASE_URL}{_setting.FINDER_IMAGE_ASSETS_URL}{noImageUrl}";
        }
        public string GetOwnProfileImageById(long candidateId)
        {

            var candidate = _context.candidates.Where(e => e.Id == candidateId).Include(e => e.Gender).FirstOrDefault();

            var candidateProfilePhoto = _context.candidatePhotos.Where(e => e.Candidate.Id == candidate.Id
                    && e.Type.Code == PhotoConstant.ProfilePhotoCode
                    && e.IsVerified != false && !e.IsDeleted)
                    .Include(e => e.PrivacyPolicyType)
                    .Include(e => e.Type)
                    .Include(e => e.Candidate).ThenInclude(e => e.Gender)
                    .OrderByDescending(o => o.Id)
                    .FirstOrDefault();

            if (candidateProfilePhoto == null) return GetProfilePhotoAvatarPath(candidate);

            return GetProfileImagePathOnlyResponse(candidateProfilePhoto);
        }
        public string GetProfileImagePathOnlyResponse(CandidatePhotoModel candidatePhoto)
        {
            return $"{_setting.DISPLAY_PHOTO_BASE_URL}{candidatePhoto.DisplayPhotoUrl}";
        }
        public bool CheckCelestial(long candidateId)
        {
            var candidateSubscription = _context.candidateSubscriptions.Include(e => e.Subscription).Where(e => e.Candidate.Id == candidateId && e.IsSubscriptionActive).FirstOrDefault();

            if (candidateSubscription.Subscription.Code == CommonConstant.CelestialCode) return true;

            return false;
        }

        public CandidateContactDetailsDTO GetCandidateContactDetail(long candidateId)
        {
            var candidateContact = _context.candidateContacts
                .Where(e => e.Candidate.Id == candidateId).Include(e => e.Type)
                .ToList();

            var primary = candidateContact
                .Where(e => e.Type.Code == CommonConstant.PrimaryContactCode)
                .FirstOrDefault();

            var residence = candidateContact
                .Where(e => e.Type.Code == CommonConstant.ResidentContactCode)
                .FirstOrDefault();

            var communication = candidateContact
                .Where(e => e.Type.Code == CommonConstant.CommunicationAddressCode)
                .FirstOrDefault();

            var addressDetails = communication?.Address;

            var address = addressDetails?.Select(e => e.Address).FirstOrDefault();

            return new CandidateContactDetailsDTO
            {
                Address = address ?? string.Empty,
                Mobile = primary?.MobilePhone != null
                     ? $"{primary.MobilePhone.CountryCode}{primary.MobilePhone.Number}"
                     : string.Empty,
                ResidencePhone = residence?.MobilePhone != null
                     ? $"{residence.MobilePhone.CountryCode}{residence.MobilePhone.Number}"
                     : string.Empty
            };
        }
        public List<CandidatePhotoDetailsDTO> getDefaultPhoto()
        {
            return new List<CandidatePhotoDetailsDTO> {
            new CandidatePhotoDetailsDTO {
                DisplayPhotoUrl= _setting.FINDER_PHOTOS_BASE_URL + _setting.FINDER_IMAGE_ASSETS_URL + PhotoConstant.NoImageMaleURL,
                Type="PFL",
                Order=1,
                PrivacyPolicyId=null,
                ThumbnailPhotoUrl=_setting.FINDER_PHOTOS_BASE_URL + _setting.FINDER_IMAGE_ASSETS_URL + PhotoConstant.NoImageMaleURL,
                PrivacyCode=null,
                IsVerified=true,
                IsPhotoAvailable=true,
                PhotoRequestInfo=null
            }
        };
        }

        private string GetHidePhotoWarning(bool isExpired, string photoType, string sendDate, string sendAfterDate)
        {
            string message = null;
            switch (photoType)
            {
                case PhotoConstant.ProfilePhotoCode:
                    message = isExpired ? ValidationMessageConstant.AlreadySendPhotoViewRequestAndExpired : ValidationMessageConstant.AlreadySendPhotoViewRequest;
                    break;
                case PhotoConstant.AlbumPhotoCode:
                    message = isExpired ? ValidationMessageConstant.AlreadySendAlbumPhotoViewRequestAndExpired : ValidationMessageConstant.AlreadySendAlbumPhotoViewRequest;
                    break;
                case PhotoConstant.FamilyPhotoCode:
                    message = isExpired ? ValidationMessageConstant.AlreadySendFamilyPhotoViewRequestAndExpired : ValidationMessageConstant.AlreadySendFamilyPhotoViewRequest;
                    break;
            }

            return message == null ? message : message.Replace(ReplacingConstant.Date, sendDate).Replace(ReplacingConstant.DateAfter, sendAfterDate);
        }

        public static string GetWorkplaceV2(string country, string state, string district, string town)
        {
            if (town != null)
            {
                if (town != string.Empty) return town;
            }
            if (district != null) return district;

            if (state != null) return state;

            if (country != null) return country;

            return null;
        }
        public async Task<List<CandidateAndSubscriptionDTO>> SendPushData(string[] membershipCodes)
        {
            // var response = await _context.candidates
            //     .Include(e => e.BloodGroup)
            //     .Include(e => e.Gender)
            //     .Include(e => e.Complexion)
            //     .Include(e => e.MaritalStatus)
            //     .Join(_context.candidateSubscriptions,
            //         c => c.Id,
            //         cs => cs.Candidate.Id,
            //         (c, cs) => new { c, cs })
            //     .Join(_context.candidateContacts,
            //         combined => combined.c.Id,
            //         cc => cc.Candidate.Id,
            //         (combined, cc) => new { combined.c, combined.cs, cc })
            //     .Where(joined => joined.cs.IsSubscriptionActive
            //                     && membershipCodes.Contains(joined.cs.Subscription.Code) // Use array `Contains` to filter by MembershipCode
            //                     && joined.cc.Type.Code == "PRE" && joined.cc.Email.EmailId != "" && joined.cc.Email.EmailId != null) // Filter by address type code
            //     .Select(joined => new CandidateAndSubscriptionDTO
            //     {
            //         candidate = joined.c,
            //         subscription = joined.cs.Subscription,
            //         candidateContact = joined.cc
            //     })
            //     .ToListAsync();
            var alertGroupCode = "367eb2f7-983d-4dd5-b616-41d40c831ade";
            var alertGroupGuid = Guid.Parse(alertGroupCode);

            var alertId = await _context.alertGroups
                .Where(ag => ag.Code == alertGroupGuid)
                .Select(ag => ag.Id)
                .FirstOrDefaultAsync();

            var response = await _context.candidates
                .Include(e => e.BloodGroup)
                .Include(e => e.Gender)
                .Include(e => e.Complexion)
                .Include(e => e.MaritalStatus)
                .Join(_context.candidateSubscriptions,
                    c => c.Id,
                    cs => cs.Candidate.Id,
                    (c, cs) => new { c, cs })
                .Join(_context.candidateContacts,
                    combined => combined.c.Id,
                    cc => cc.Candidate.Id,
                    (combined, cc) => new { combined.c, combined.cs, cc })
                .Join(_context.candidateAlertSettings,
                    combined => combined.c.Id,
                    cas => cas.Candidate.Id,
                    (combined, cas) => new { combined.c, combined.cs, combined.cc, cas })
                .Where(joined =>
                    joined.cs.IsSubscriptionActive &&
                    membershipCodes.Contains(joined.cs.Subscription.Code) &&
                    joined.cc.Type.Code == "PRE" &&
                    !string.IsNullOrWhiteSpace(joined.cc.Email.EmailId) &&
                    joined.cas.Alert.Id == alertId &&
                    joined.cas.IsEmail)
                .Select(joined => new CandidateAndSubscriptionDTO
                {
                    candidate = joined.c,
                    subscription = joined.cs.Subscription,
                    candidateContact = joined.cc
                })
                .ToListAsync()
                .ContinueWith(task => task.Result
                .DistinctBy(dto => dto.candidate.Id)
                .ToList());

            return response;
        }
        public async Task<List<CandidateAndSubscriptionDTO>> SendPushData(string[] membershipCodes, int quarter)
        {
            var quarterMonths = quarter switch
            {
                1 => new[] { 1, 2, 3 },     // Q1: Jan-Mar
                2 => new[] { 4, 5, 6 },     // Q2: Apr-Jun
                3 => new[] { 7, 8, 9 },     // Q3: Jul-Sep
                4 => new[] { 10, 11, 12 },  // Q4: Oct-Dec
                _ => throw new ArgumentException("Invalid quarter. Must be 1 to 4.")
            };
            // var response = await _context.candidates
            //     .Include(e => e.BloodGroup)
            //     .Include(e => e.Gender)
            //     .Include(e => e.Complexion)
            //     .Include(e => e.MaritalStatus)
            //     .Join(_context.candidateSubscriptions,
            //         c => c.Id,
            //         cs => cs.Candidate.Id,
            //         (c, cs) => new { c, cs })
            //     .Join(_context.candidateContacts,
            //         combined => combined.c.Id,
            //         cc => cc.Candidate.Id,
            //         (combined, cc) => new { combined.c, combined.cs, cc })
            //     .Where(joined => joined.cs.IsSubscriptionActive
            //                     && membershipCodes.Contains(joined.cs.Subscription.Code) // Use array `Contains` to filter by MembershipCode
            //                   && quarterMonths.Contains(joined.cs.StartTimeStamp.Value.Month)
            //                     && joined.cc.Type.Code == "PRE" && joined.cc.Email.EmailId != "" && joined.cc.Email.EmailId != null) // Filter by address type code
            //     .Select(joined => new CandidateAndSubscriptionDTO
            //     {
            //         candidate = joined.c,
            //         subscription = joined.cs.Subscription,
            //         candidateContact = joined.cc
            //     })
            //     .ToListAsync();
            var alertGroupCode = "367eb2f7-983d-4dd5-b616-41d40c831ade";
            var alertGroupGuid = Guid.Parse(alertGroupCode);

            var alertId = await _context.alertGroups
                .Where(ag => ag.Code == alertGroupGuid)
                .Select(ag => ag.Id)
                .FirstOrDefaultAsync();

            var response = await _context.candidates
                .Include(e => e.BloodGroup)
                .Include(e => e.Gender)
                .Include(e => e.Complexion)
                .Include(e => e.MaritalStatus)
                .Join(_context.candidateSubscriptions,
                    c => c.Id,
                    cs => cs.Candidate.Id,
                    (c, cs) => new { c, cs })
                .Join(_context.candidateContacts,
                    combined => combined.c.Id,
                    cc => cc.Candidate.Id,
                    (combined, cc) => new { combined.c, combined.cs, cc })
                .Join(_context.candidateAlertSettings,
                    combined => combined.c.Id,
                    cas => cas.Candidate.Id,
                    (combined, cas) => new { combined.c, combined.cs, combined.cc, cas })
                .Where(joined =>
                    joined.cs.IsSubscriptionActive &&
                    membershipCodes.Contains(joined.cs.Subscription.Code) &&
                    quarterMonths.Contains(joined.cs.StartTimeStamp.Value.Month) &&
                    joined.cc.Type.Code == "PRE" &&
                    !string.IsNullOrWhiteSpace(joined.cc.Email.EmailId) &&
                    joined.cas.Alert.Id == alertId &&
                    joined.cas.IsEmail)
                .Select(joined => new CandidateAndSubscriptionDTO
                {
                    candidate = joined.c,
                    subscription = joined.cs.Subscription,
                    candidateContact = joined.cc
                })
                .ToListAsync()
                .ContinueWith(task => task.Result
                .DistinctBy(dto => dto.candidate.Id)
                .ToList());
            return response;
        }
        public string GetReligion(string treePath)
        {
            if (treePath == null) return null;

            LTree tpath = treePath;

            var religion = _context.religions.Where(e => tpath.IsDescendantOf(e.TreePath) && e.Type == ReligionConstants.SubCasteType).FirstOrDefault();

            return religion?.Name;
        }
        public async Task<IQueryable<CandidatePartnerSearch>> CandidateSearchByMyMatchQueryBuilder(long candidateId, long genderId)
        {
            var candidate = await _context.candidates.Where(e => e.Id == candidateId)
                                                        .Include(e => e.Gender)
                                                        .Include(e => e.BodyType)
                                                        .Include(e => e.Complexion)
                                                        .Include(e => e.MaritalStatus)
                                                        .Include(e => e.MotherTongue)
                                                        .Include(e => e.NativeCountry)
                                                        .Include(e => e.NativeState)
                                                        .Include(e => e.NativeDistrict)
                                                        .Include(e => e.NativeTown)
                                                        .Include(e => e.CreatedContact)
                                                        .FirstOrDefaultAsync();

            int age = CalculateAge(candidate.DOB);

            var candidateWithActiveMemberShip = _context.candidateSubscriptions.Where(e => e.Candidate.Id == candidateId && e.IsSubscriptionActive).Include(e => e.Subscription).FirstOrDefault();

            var query = @"WITH CandidateBasicInfo 
                       as(
	select
		 c.""Id"",C.""Name"" as ""CandidateName"",C.""ProfileId"",C.""RegistrationId"" ,C.""HeightInCentimeter"",c.""IsFeatured""
	    ,calculate_age(c.""DOB"") as ""Age"" ,c.""LastLogIn"",c.""IsOnline"",c.""IsSpecialNeeds"",
	    c.""IsMatchFilter"",c.""IsPaidFilter"",c.""IsAgeFilter"",c.""IsHeightFilter""
	    ,c.""EducationDetails"" ,
		c.""ReligionTreePath"",
		case when (c.""ChildrenWithMe"" =0 and c.""ChildrenNotWithMe"" =0) or (c.""ChildrenWithMe""=0
		and c.""ChildrenNotWithMe"" is null)  or (c.""ChildrenWithMe"" =0
		and c.""ChildrenNotWithMe"" is null ) or (c.""ChildrenWithMe"" is null
		and c.""ChildrenNotWithMe"" is null) then false else true end as ""IsHavingChildern"",
		cp.""Name""  as ""Complexion"",
		ms.""Name""  as ""MaritalStatus"",
		cpn.""Details""  as ""ProfessionDetails"",cpn.""WorkingCountryId"",
		s.""Name""  as ""SubscriptionName"", s.""Colour""  as ""SubscriptionColor"",cs.""DisplayStartTimeStamp""  as ""SubscriptionStartDate"",s.""IsPremium"",
		c.""NativeCountryId"",c.""NativeStateId"",c.""NativeDistrictId"",
		c.""BodyTypeId"",c.""ComplexionId"",c2.""Name"" as ""WorkingCountry"",d.""Name"" as ""WorkingDistrict"",
        t.""Name"" as ""WorkingTown"",cpn.""Organization"",
        c.""NativePlace"",s.""Id"" as ""SubscriptionId"", gndr.""Code"" as ""GenderCode"",stat.""Name"" as ""WorkingState"",p.""Name"" as ""ProfessionCategoryName"",
		EXISTS (SELECT 1 
                  	FROM  candidate_tagging_visit ctv 
                WHERE ctv.""SourceCandidateId"" = @CandidateId 
                   AND  ctv.""TaggedCandidateId"" =c.""Id"")""AlreadySeen"",
                   
        
       EXISTS (SELECT 1
       				FROM  candidate_tagging_contact ctc   
    			WHERE ctc.""CandidateId""  =   @CandidateId 
    				AND  ctc.""TaggedCandidateId"" =c.""Id"") ""AlreadyContacted"",
    				
    	EXISTS (SELECT 1
   					FROM  candidate_tagging_shortlist cts     
    			WHERE cts.""SourceCandidateId"" =   @CandidateId  
    				AND  cts.""TaggedCandidateId"" =c.""Id"") ""AlreadyShortListed"",
    				
    	EXISTS (SELECT 1 
    				FROM candidate_message  cmm   
				WHERE cmm.""SenderCandidateId"" =   @CandidateId   
					AND cmm.""ReceiverCandidateId""=c.""Id""  
					AND cmm.""IsWithdraw"" =FALSE 
					AND  cmm.""MessageCategoryId""=1 
					AND cmm.""MessageStatusId"" =3) ""AlreadyInterestSent"",
	   
		EXISTS (SELECT 1 
					FROM candidate_tagging_block ctb 
				WHERE (ctb.""SourceCandidateId"" =  @CandidateId   AND ctb.""TaggedCandidateId"" =c.""Id"") 
					OR (ctb.""SourceCandidateId""=c.""Id"" AND ctb.""TaggedCandidateId""=  @CandidateId  ) 
					AND ctb.""IsAdminSourceDeleted"" =FALSE AND ctb.""IsSourceDeleted"" =FALSE) ""Blocked"",
					
		EXISTS (select 1 
					from candidate_tagging_ignore cti 
				where cti.""SourceCandidateId"" =  @CandidateId 
					AND cti.""TaggedCandidateId"" =c.""Id""
					AND cti.""IsAdminSourceDeleted"" =FALSE 
					AND cti.""IsSourceDeleted"" =FALSE) ""Ignored"",
					
    	EXISTS (SELECT 1 
        			FROM candidate_wishlists   w
        		WHERE w.""IsDeleted""  = FALSE 
        			AND w.""CandidateId""  =   @CandidateId 
        			AND c.""Id"" = ANY(w.""TaggedCandidateIds"")) as ""IsWishlisted"",
        			
         EXISTS (SELECT 1 
        			FROM candidate_photo cpo
        		WHERE c.""Id""=cpo.""CandidateId"" 
        		   and cpo.""TypeId""=1 
        		   and cpo.""IsDeleted"" =false
        		   and coalesce(cpo.""IsVerified"",true) !=false) as ""WithPhoto""					
	from candidate c
		inner join candidate_subscription cs on cs.""CandidateId"" =c.""Id"" and cs.""IsSubscriptionActive""
		inner join ""subscription"" s on cs.""SubscriptionId"" =s.""Id"" and s.""IsSearchable"" =true
        inner join gender gndr on c.""GenderId"" =gndr.""Id"" 
		left join complexion cp on  c.""ComplexionId""=cp.""Id""
		left join marital_status ms  on  c.""MaritalStatusId""=ms.""Id""
		left join candidate_profession cpn on cpn.""CandidateId"" =c.""Id""  and cpn.""IsActive"" and cpn.""IsDeleted""=false
        left join profession p on cpn.""ProfessionId"" =p.""Id"" 
		left join country c2 on cpn.""WorkingCountryId"" =c2.""Id"" 
		left join state stat on cpn.""WorkingStateId"" =stat.""Id"" 
		left join district d on cpn.""WorkingDistrictId"" =d.""Id"" 
		left join town t on cpn.""WorkingTownId"" =t.""Id"" 
	where c.""IsDeleted""=false and c.""IsBlacklisted""=false and c.""IsHiddenFilter""=false 
    and c.""ConfidentialId"" is null ORDER BY CS.""DisplayStartTimeStamp"" DESC";

            var parameters = new List<NpgsqlParameter>();
            var baseConditions = new List<string>();
            parameters.Add(new NpgsqlParameter("CandidateId", candidateId));


            baseConditions.Add("c.\"GenderId\" != @GenderId");
            parameters.Add(new NpgsqlParameter("GenderId", genderId));

            if (candidateWithActiveMemberShip.Subscription.Code == MembershipTypeConstant.UnderGraduate)
            {
                baseConditions.Add("cs.\"SubscriptionId\" = @CandidateSubscriptionId");
                parameters.Add(new NpgsqlParameter("CandidateSubscriptionId", candidateWithActiveMemberShip.Subscription.Id));
            }


            var candidatepreference = await _context.preferences.Where(e => e.Candidate.Id == candidateId).FirstOrDefaultAsync();

            if (candidatepreference != null)
            {

                if (candidatepreference.IsSpecialNeed != null)
                {
                    baseConditions.Add("c.\"IsSpecialNeeds\" = @PreferedIspecialNeed");
                    parameters.Add(new NpgsqlParameter("PreferedIspecialNeed", candidatepreference.IsSpecialNeed));
                }

                if (candidatepreference.HeightMax != null && candidatepreference.HeightMin != null)
                {
                    baseConditions.Add("c.\"HeightInCentimeter\" BETWEEN @MinHeight AND @MaxHeight");
                    parameters.Add(new NpgsqlParameter("MinHeight", candidatepreference.HeightMin));
                    parameters.Add(new NpgsqlParameter("MaxHeight", candidatepreference.HeightMax));
                }
            }

            var candidateMaritalStatus = await _context.preferredMaritalStatuses.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.MaritalStatus).ToListAsync();

            if (candidateMaritalStatus.Any() && !candidateMaritalStatus.Select(e => e.MaritalStatus.Code).Contains(CommonConstant.AnyCode))
            {
                baseConditions.Add("c.\"MaritalStatusId\" = Any(@PreferedMaritalStatusIds)");
                parameters.Add(new NpgsqlParameter("PreferedMaritalStatusIds", candidateMaritalStatus.Select(e => e.MaritalStatus.Id).ToList()));
            }

            var candidatelanguage = await _context.preferredLanguages.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.Language).ToListAsync();

            if (candidatelanguage.Any() && !candidatelanguage.Select(e => e.Language.Code).Contains(CommonConstant.AnyCode))
            {
                baseConditions.Add("c.\"MotherTongueId\" = Any(@PreferedMotherTongue)");
                parameters.Add(new NpgsqlParameter("PreferedMotherTongue", candidatelanguage.Select(e => e.Language.Id).ToList()));
            }

            var candidateBodyType = await _context.preferredBodyTypes.Where(e => e.Candidate.Id == candidateId && e.IsSelected).Include(e => e.BodyType).ToListAsync();

            if (candidateBodyType.Count() > 0 && !candidateBodyType.Select(e => e.BodyType.Code).Contains(CommonConstant.AnyCode))
            {
                baseConditions.Add("c.\"BodyTypeId\" = Any(@PreferedBodyTypeIds)");
                parameters.Add(new NpgsqlParameter("PreferedBodyTypeIds", candidateBodyType.Select(e => e.BodyType.Id).ToList()));
            }

            var candidateComplexion = await _context.preferredComplexions.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.Complexion).ToListAsync();
            if (candidateComplexion.Count() > 0 && !candidateComplexion.Select(e => e.Complexion.Code).Contains(CommonConstant.AnyCode))
            {
                baseConditions.Add("c.\"ComplexionId\" = Any(@PreferedComplexionIds)");
                parameters.Add(new NpgsqlParameter("PreferedComplexionIds", candidateComplexion.Select(e => e.Complexion.Id).ToList()));
            }

            var candidateCreator = await _context.preferredCreators.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.CreatedContact).ToListAsync();

            if (candidateCreator.Count() > 0 && !candidateCreator.Select(e => e.CreatedContact.Code).Contains(CommonConstant.AnyCode))
            {

                var creatorAndParentIds = await _context.addressTypes.Where(e =>
                    candidateCreator.Select(e => e.CreatedContact.Id).ToList().Contains(e.Id) ||
                    candidateCreator.Select(e => e.CreatedContact.Id).ToList().Contains(e.ParentId.Value)).Select(e =>
                        e.Id
                    ).ToListAsync();


                baseConditions.Add("c.\"CreatedContactId\" = Any(@PreferedCreatorsIds)");
                parameters.Add(new NpgsqlParameter("PreferedCreatorsIds", creatorAndParentIds));
            }

            var candidateProfession = await _context.preferredProfessions.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.Profession).ToListAsync();

            if (candidateProfession.Count() > 0 && !candidateProfession.Select(e => e.Profession.Code).Contains(CommonConstant.AnyCode))
            {
                baseConditions.Add("cpn.\"ProfessionId\" = Any(@PreferedOccupationIds)");
                parameters.Add(new NpgsqlParameter("PreferedOccupationIds", candidateProfession.Select(e => e.Profession.Id).ToList()));
            }

            var candidateOrganizatrionType = await _context.preferredOrganizationTypes.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.OrganizationType).ToListAsync();

            if (candidateOrganizatrionType.Any() && !candidateOrganizatrionType.Select(e => e.OrganizationType.Code).Contains(CommonConstant.AnyCode))
            {
                baseConditions.Add("cpn.\"OrganizationTypeId\" = Any(@PreferedOrganizationIds)");
                parameters.Add(new NpgsqlParameter("PreferedOrganizationIds", candidateOrganizatrionType.Select(e => e.OrganizationType.Id).ToList()));
            }

            var candidateIncome = await _context.preferredIncomes.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.Income).ToListAsync();

            if (candidateIncome.Any() && !candidateIncome.Select(e => e.Income.Code).Contains(CommonConstant.AnyCode))
            {

                var incomeAndParentIds = await _context.incomes.Where(e =>
                    candidateIncome.Select(e => e.Income.Id).ToList().Contains(e.Id) ||
                    candidateIncome.Select(e => e.Income.Id).ToList().Contains(e.ParentId.Value)).Select(e =>
                        e.Id
                    ).ToListAsync();

                baseConditions.Add("cpn.\"IncomeId\" = Any(@PreferedIncomeIds)");
                parameters.Add(new NpgsqlParameter("PreferedIncomeIds", incomeAndParentIds));
            }


            var candidateNativeLocation = await _context.preferredLocations.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected && e.IsNative).Include(e => e.Country)
                                                                .Include(e => e.State)
                                                                .Include(e => e.District)
                                                                .Include(e => e.Town).ToListAsync();

            if (candidateNativeLocation.Any())
            {

                if (candidateNativeLocation.Where(e => e.Country != null).Any() && (!candidateNativeLocation.Select(e => e.Country?.Code).Contains(CommonConstant.AnyCode)))
                {

                    var candidatePreferedNatvieCountry = candidateNativeLocation.Select(e => e.Country?.Id).Distinct().Where(e => e != null).ToList();

                    baseConditions.Add("c.\"NativeCountryId\" = Any(@PreferedNativeCountryIds)");
                    parameters.Add(new NpgsqlParameter("PreferedNativeCountryIds", candidatePreferedNatvieCountry));

                }

                if (candidateNativeLocation.Where(e => e.State != null).Any() && (!candidateNativeLocation.Select(e => e.State?.Code).Contains(CommonConstant.AnyCode)))
                {

                    var candidatePreferedState = candidateNativeLocation.Select(e => e.State?.Id).Distinct().Where(e => e != null).ToList();

                    baseConditions.Add("c.\"NativeStateId\" = Any(@PreferedNativeStateIds)");
                    parameters.Add(new NpgsqlParameter("PreferedNativeStateIds", candidatePreferedState));

                }

                if (candidateNativeLocation.Where(e => e.District != null).Any() && (!candidateNativeLocation.Select(e => e.District?.Code).Contains(CommonConstant.AnyCode)))
                {

                    var candidateNativeDistrict = candidateNativeLocation.Select(e => e.District?.Id).Distinct().Where(e => e != null).ToList();


                    baseConditions.Add("c.\"NativeDistrictId\" = Any(@PreferedNativeDistrictId)");
                    parameters.Add(new NpgsqlParameter("PreferedNativeDistrictId", candidateNativeDistrict));
                }

                if (candidateNativeLocation.Where(e => e.Town != null).Any() && (!candidateNativeLocation.Select(e => e.Town?.Code).Contains(CommonConstant.AnyCode)))
                {

                    var candidatePreferedTown = candidateNativeLocation.Select(e => e.Town?.Id).Distinct().Where(e => e != null).ToList();
                    baseConditions.Add("c.\"NativeTownId\" = Any(@PreferedNativeTownId)");
                    parameters.Add(new NpgsqlParameter("PreferedNativeTownId", candidatePreferedTown));
                }
            }

            var candidateWorkLocation = await _context.preferredLocations.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected && !e.IsNative).Include(e => e.Country)
                                                                  .Include(e => e.State)
                                                                  .Include(e => e.District)
                                                                  .Include(e => e.Town).ToListAsync();

            if (candidateWorkLocation.Any())
            {

                if (candidateWorkLocation.Where(e => e.Country != null).Any() && (!candidateWorkLocation.Select(e => e.Country?.Code).Contains(CommonConstant.AnyCode)))
                {
                    var candidatePreferedWorkingCountry = candidateWorkLocation.Select(e => e.Country?.Id).Distinct().Where(e => e != null).ToList();

                    baseConditions.Add("cpn.\"WorkingCountryId\" = Any(@PreferedWorkingCountryIds)");
                    parameters.Add(new NpgsqlParameter("PreferedWorkingCountryIds", candidatePreferedWorkingCountry));

                }

                if (candidateWorkLocation.Where(e => e.State != null).Any() && (!candidateWorkLocation.Select(e => e.State?.Code).Contains(CommonConstant.AnyCode)))
                {
                    var candidatePreferedWorkingState = candidateWorkLocation.Select(e => e.State?.Id).Distinct().Where(e => e != null).ToList();

                    baseConditions.Add("cpn.\"WorkingStateId\" = Any(@PreferedWorkingStateIds)");
                    parameters.Add(new NpgsqlParameter("PreferedWorkingStateIds", candidatePreferedWorkingState));

                }

                if (candidateWorkLocation.Where(e => e.District != null).Any() && (!candidateWorkLocation.Select(e => e.District?.Code).Contains(CommonConstant.AnyCode)))
                {

                    var candidatePreferedWorkingDistrict = candidateWorkLocation.Select(e => e.District?.Id).Distinct().Where(e => e != null).ToList();

                    baseConditions.Add("cpn.\"WorkingDistrictId\" = Any(@PreferedWorkingDistrictId)");
                    parameters.Add(new NpgsqlParameter("PreferedWorkingDistrictId", candidatePreferedWorkingDistrict));
                }

                if (candidateWorkLocation.Where(e => e.Town != null).Any() && (!candidateWorkLocation.Select(e => e.Town?.Code).Contains(CommonConstant.AnyCode)))
                {
                    var candidatePreferedWorkingTown = candidateWorkLocation.Select(e => e.Town?.Id).Distinct().Where(e => e != null).ToList();

                    baseConditions.Add("cpn.\"WorkingTownId\" = Any(@PreferedWorkingTownId)");
                    parameters.Add(new NpgsqlParameter("PreferedWorkingTownId", candidatePreferedWorkingTown));
                }
            }


            if (baseConditions.Any())
            {
                query += " AND " + string.Join(" AND ", baseConditions) + "),";
            }

            query += @"CandidatePreferenceFilteredData as (
                    select
                    cb.""Id"",cb.""CandidateName"",cb.""ProfileId"",cb.""RegistrationId"",cb.""HeightInCentimeter"",cb.""Age"",cb.""LastLogIn""
                    ,cb.""IsOnline"",cb.""IsFeatured"",
                    cb.""IsSpecialNeeds"",cb.""BodyTypeId"",
                    cb.""IsMatchFilter"",cb.""IsPaidFilter"",cb.""IsAgeFilter"",cb.""IsHeightFilter"" ,            
                    cb.""EducationDetails"",cb.""IsHavingChildern"",
                    cb.""ReligionTreePath"",cb.""Complexion"",cb.""ProfessionDetails"",cb.""WorkingCountryId"",
                    cb.""SubscriptionName"",cb.""SubscriptionColor"",cb.""SubscriptionStartDate"",
                    cb.""NativeCountryId"",cb.""NativeStateId"",cb.""NativeDistrictId"" ,
                    cf.""FamilyStatusId"" ,cb.""ComplexionId"",cb.""IsWishlisted"",
                    cb.""WorkingCountry"",cb.""WorkingDistrict"",cb.""WorkingTown"",cb.""Organization"",cb.""NativePlace"",cb.""SubscriptionId"",cb.""GenderCode"",cb.""WorkingState""
                    ,cb.""IsPremium"",cb.""ProfessionCategoryName"",cb.""MaritalStatus""
                    from CandidateBasicInfo cb
                        left join candidate_education ce on cb.""Id"" = ce.""CandidateId""  and ce.""IsSelected"" and ce.""IsDeleted"" =false
                        left join candidate_family cf  on cf.""CandidateId"" =cb.""Id""
                        left join candidate_branch cbs on cb.""Id""=cbs.""CandidateId""  and cbs.""IsBranchActive""
                        left join religion r on  cb.""ReligionTreePath""::ltree = r.treepath and r.""IsVerified"" and r.""IsActive"" and r.""IsDeleted"" =false
                        left join candidate_habits ch on cb.""Id""=ch.""CandidateId""   and ch.""IsSelected""  and ch.""IsActive"" 
                        left join candidate_disability cd on cb.""Id""=cd.""CandidateId""   
                    where 
                        cb.""Ignored""=false 
                        and cb.""Blocked""=false";

            var preferenceConditions = new List<string>();
            parameters.Add(new NpgsqlParameter("CandidateAge", age));




            if (candidateWithActiveMemberShip.Subscription.Code == MembershipTypeConstant.Xpress)
            {
                if (candidate.Gender.Code == GenderConstant.MaleCode)
                {
                    preferenceConditions.Add("(cb.\"Age\" >= 30 and cb.\"Age\" <= @CandidateAge)");
                }

                if (candidate.Gender.Code == GenderConstant.FemaleCode)
                {
                    preferenceConditions.Add("(cb.\"Age\" >= @CandidateAge)");
                }
            }

            if (candidatepreference != null)
            {

                preferenceConditions.Add("(cb.\"Age\" BETWEEN @MinAge AND @MaxAge)");
                parameters.Add(new NpgsqlParameter("MinAge", candidatepreference.AgeMin));
                parameters.Add(new NpgsqlParameter("MaxAge", candidatepreference.AgeMax));


                if (candidatepreference.IsHavingChildern != null)
                {
                    preferenceConditions.Add("cb.\"IsHavingChildern\" = @PreferedIsChildren");
                    parameters.Add(new NpgsqlParameter("PreferedIsChildren", candidatepreference.IsHavingChildern));
                }

            }

            var candidateFamilyStatus = await _context.preferredFamilyStatuses.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.FamilyStatus).ToListAsync();

            if (candidateFamilyStatus.Any() && !candidateFamilyStatus.Select(e => e.FamilyStatus.Code).Contains(CommonConstant.AnyCode))
            {
                preferenceConditions.Add("cf.\"FamilyStatusId\" =  Any(@PreferedFamilyStatusIds)");
                parameters.Add(new NpgsqlParameter("PreferedFamilyStatusIds", candidateFamilyStatus.Select(e => e.FamilyStatus.Id).ToList()));
            }


            #region New change : add prefered education based on legacy 

            var selectEducationBasedOnCategory = await _context.preferredEducations.Include(e => e.Education)
                    .Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsActive && e.IsSelected).Select(e => e.Education.EducationCategory.Id).Distinct().ToListAsync();

            var preferedEducation = await _context.educations.Where(e => e.IsActive && !e.IsDeleted && selectEducationBasedOnCategory.Contains(e.EducationCategory.Id))
                    .Include(e => e.EducationCategory)
                    .Select(e => new
                    {
                        Id = e.Id,
                        Code = e.Code
                    }).ToListAsync();


            if (preferedEducation.Any() && !preferedEducation.Select(e => e.Code).Contains(CommonConstant.AnyCode))
            {
                preferenceConditions.Add("ce.\"EducationId\" =  Any(@PreferedEducationIds)");
                parameters.Add(new NpgsqlParameter("PreferedEducationIds", preferedEducation.Select(e => e.Id).ToList()));
            }
            #endregion


            var candidateIspecialNeed = await _context.preferredSpecialNeeds.Where(e => e.Candidate.Id == candidateId && !e.IsDeleted && e.IsSelected).Include(e => e.Disability).ToListAsync();

            if (candidateIspecialNeed.Any() && !candidateIspecialNeed.Select(e => e.Disability.Code).Contains(CommonConstant.AnyCode))
            {
                preferenceConditions.Add("cd.\"DisabilityId\" = Any(@PreferedDisabilityIds)");
                parameters.Add(new NpgsqlParameter("PreferedDisabilityIds", candidateIspecialNeed.Select(e => e.Disability.Id).ToList()));
            }

            var preferedReligionDetails = await _context.preferredReligions.Where(e => e.Candidate.Id == candidateId && e.IsActive && !e.IsDeleted && e.IsSelected).Include(e => e.Candidate).Join(
         _context.religions,
         p => (LTree)p.ReligionTreePath,
         r => (LTree)r.TreePath,
         (preferenceReligion, religion) => new { Id = religion.Id, Name = religion.Name }).ToListAsync();

            if (preferedReligionDetails.Any() && !preferedReligionDetails.Select(e => e.Name).Contains(PreferencesConstant.Any))
            {
                preferenceConditions.Add("r.parentid = Any(@PreferedDenominationIds)");
                parameters.Add(new NpgsqlParameter("PreferedDenominationIds", preferedReligionDetails.Select(e => e.Id).ToList()));
            }

            if (preferenceConditions.Any())
            {
                query += " and " + string.Join(" AND ", preferenceConditions) + "),";
            }
            else
            {
                query += "),";
            }

            query += @"CandidateSearchVisibilityFilter as (
    select
        t.""Id"",t.""CandidateName"",t.""ProfileId"",t.""RegistrationId"",t.""HeightInCentimeter"",t.""Age"",t.""LastLogIn""
        ,t.""IsOnline"",t.""IsFeatured"",
        t.""IsSpecialNeeds"",t.""BodyTypeId"",
        t.""IsMatchFilter"",t.""IsPaidFilter"",t.""IsAgeFilter"",t.""IsHeightFilter"" ,
        t.""EducationDetails"",t.""IsHavingChildern"",
        t.""ReligionTreePath"",t.""Complexion"",t.""ProfessionDetails"",t.""WorkingCountryId"",
        t.""SubscriptionName"",t.""SubscriptionColor"",t.""SubscriptionStartDate"",
        t.""NativeCountryId"",t.""NativeStateId"",t.""NativeDistrictId"" ,
        t.""FamilyStatusId"" ,t.""ComplexionId"",t.""IsWishlisted""
        ,t.""WorkingCountry"",t.""WorkingDistrict"",t.""WorkingTown"",t.""Organization"",t.""NativePlace"",t.""SubscriptionId"",t.""GenderCode"",t.""WorkingState""
         ,t.""IsPremium"",t.""ProfessionCategoryName"",t.""MaritalStatus"",chs.""CometId""
     from CandidatePreferenceFilteredData t 
     left join candidate_chat_setting chs on t.""Id""=chs.""CandidateId"" and chs.""IsActive""=true ";

            var searchVisibilityCondition = new List<string>();

            var checkPremium = await _context.candidateSubscriptions.Where(e => e.Candidate.Id == candidateId && e.IsSubscriptionActive
                                                                                   && e.Subscription.IsPremium == true)
                                                                           .Include(e => e.Candidate)
                                                                           .Include(e => e.Subscription).AnyAsync();



            searchVisibilityCondition.Add("(case when @CandidateIsPremium=true then t.\"IsPaidFilter\" or t.\"IsPaidFilter\"=false else t.\"IsPaidFilter\"=false end)");
            parameters.Add(new NpgsqlParameter("CandidateIsPremium", checkPremium));

            searchVisibilityCondition.Add("(t.\"IsAgeFilter\"=false and (case when @CandidateGender='M' then t.\"Age\"<= @CandidateAge else t.\"Age\">=@CandidateAge end) or t.\"IsAgeFilter\") ");

            parameters.Add(new NpgsqlParameter("CandidateGender", candidate.Gender.Code));
            parameters.Add(new NpgsqlParameter("CandidateAge", age));

            searchVisibilityCondition.Add("(t.\"IsHeightFilter\"=false and (case when @CandidateGender='M' then t.\"HeightInCentimeter\"<= @CandidateHeight else t.\"HeightInCentimeter\">= @CandidateHeight end) or t.\"IsHeightFilter\")");
            parameters.Add(new NpgsqlParameter("CandidateHeight", candidate.HeightInCentimeter));

            if (searchVisibilityCondition.Any())
            {
                query += " where " + string.Join(" AND ", searchVisibilityCondition) + "),";
            }

            query += @"FinalResult as(
                        SELECT svf.* FROM CandidateSearchVisibilityFilter svf WHERE svf.""IsMatchFilter"" = false 
                        union all
                        SELECT svf.* FROM CandidateSearchVisibilityFilter svf left join preference p  on svf.""Id""= p.""CandidateId""
                            left join prefered_body_type pbt on svf.""Id""=pbt.""CandidateId"" and pbt.""IsSelected""  and pbt.""IsDeleted"" =false
                            left join prefered_complexion pc on svf.""Id""=pc.""CandidateId"" and pc.""IsSelected""  and pc.""IsDeleted"" =false
                            left join prefered_education pe  on svf.""Id""=pe.""CandidateId"" and pe.""IsSelected""  and pe.""IsDeleted"" =false
                            left join prefered_family_status pfs on svf.""Id""=pfs.""CandidateId"" and pfs.""IsSelected""  and pfs.""IsDeleted"" =false
                            left join prefered_income pi2 on svf.""Id""=pi2.""CandidateId"" and pi2.""IsSelected""  and pi2.""IsDeleted"" =false
                            left join prefered_language pl on  svf.""Id""=pl.""CandidateId"" and pl.""IsSelected""  and pl.""IsDeleted"" =false
                           left join prefered_location pl2  on svf.""Id""=pl2.""CandidateId"" and pl2.""IsSelected""  and pl2.""IsDeleted"" =false and pl2.""IsNative"" =false
                            left join prefered_marital_status pms   on svf.""Id""=pms.""CandidateId"" and pms.""IsSelected""  and pms.""IsDeleted"" =false
                            left join prefered_organization_type pot on svf.""Id""=pot.""CandidateId"" and pot.""IsSelected""  and pot.""IsDeleted"" =false
                            left join prefered_creator pc3 on svf.""Id""=pc3.""CandidateId"" and pc3.""IsSelected""  and pc3.""IsDeleted"" =false
                            left join prefered_profession pp on svf.""Id""=pp.""CandidateId"" and pp.""IsSelected""  and pp.""IsDeleted"" =false
                            left join  prefered_special_needs psn on svf.""Id""=psn.""CandidateId"" and psn.""IsSelected""  and psn.""IsDeleted"" =false
                            left join prefered_religion pr on svf.""Id""=pr.""CandidateId"" and pr.""IsSelected""  and pr.""IsDeleted"" =false
                            left join prefered_location pln2  on svf.""Id""=pln2.""CandidateId"" and pln2.""IsSelected""  and pln2.""IsDeleted"" =false  and pln2.""IsNative"" =true
                        where svf.""IsMatchFilter""";

            var matchFilterCondition = new List<string>();

            matchFilterCondition.Add("((@CandidateAge BETWEEN p.\"AgeMin\" AND p.\"AgeMax\") and (@CandidateHeight BETWEEN p.\"HeightMin\" AND p.\"HeightMax\"))");

            matchFilterCondition.Add("(p.\"IsSpecialNeed\"= @CandidateIspecialNeed or p.\"IsSpecialNeed\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateIspecialNeed", candidate.IsSpecialNeeds));

            matchFilterCondition.Add("(pbt.\"BodyTypeId\"= any(@CandidateBodyType) or pbt.\"BodyTypeId\" is null)");
            var bodyTypeWithAny = await _context.bodyTypes.Where(e => e.Code == CommonConstant.AnyCode || e.Id == (candidate.BodyType == null ? null : candidate.BodyType.Id)).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateBodyType", bodyTypeWithAny));

            matchFilterCondition.Add("(pc.\"ComplexionId\"= any(@CandidateComplexion) or pc.\"ComplexionId\" is null)");
            var complexionWithAny = await _context.complexions.Where(e => e.Code == CommonConstant.AnyCode || e.Id == (candidate.Complexion == null ? null : candidate.Complexion.Id)).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateComplexion", complexionWithAny));

            matchFilterCondition.Add("(pe.\"EducationId\" = any (@CandidateEducation) or pe.\"EducationId\" is null)");
            var candidateEducations = await _context.candidateEducations.Where(e => e.Candidate.Id == candidateId && e.IsSelected && e.IsActive && !e.IsDeleted).Include(e => e.Education).Select(e => e.Education.Id).ToListAsync();
            var educationWithAny = await _context.educations.Where(e => e.Code == CommonConstant.AnyCode || candidateEducations.Contains(e.Id)).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateEducation", educationWithAny));

            matchFilterCondition.Add("(pfs.\"FamilyStatusId\"=Any(@CandidateFamilyStatus) or pfs.\"FamilyStatusId\" is null)");
            var candidateFamily = await _context.candidateFamilies.Where(e => e.Candidate.Id == candidateId).Include(e => e.FamilyStatus).FirstOrDefaultAsync();
            var familyStatusWithAny = await _context.familyStatuses.Where(e => e.Code == CommonConstant.AnyCode || e.Id == (candidateFamily.FamilyStatus == null ? null : candidateFamily.Id)).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateFamilyStatus", familyStatusWithAny));

            matchFilterCondition.Add("(pi2.\"IncomeId\" = Any(@CandidateIncome) or pi2.\"IncomeId\" is null)");
            var candidateProfessions = await _context.candidateProfessions.Include(e => e.Profession).Include(e => e.Income).Include(e => e.OrganizationType).Include(e => e.WorkingCountry).Include(e => e.WorkingState).Include(e => e.WorkingTown).Include(e => e.WorkingDistrict).Where(e => e.Candidate.Id == candidateId).FirstOrDefaultAsync();
            var incomeWithAny = await _context.incomes.Where(e => e.Id == (candidateProfessions.Income == null ? null : candidateProfessions.Income.Id) || e.Code == CommonConstant.AnyCode).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateIncome", incomeWithAny));

            matchFilterCondition.Add("(pl.\"LanguageId\"=@CandidateLanguage or pl.\"LanguageId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateLanguage", candidate.MotherTongue.Id));

            matchFilterCondition.Add("(pms.\"MaritalStatusId\"= any (@CandidateMaritalStatus) or pms.\"MaritalStatusId\" is null)");
            var maritalStatusWithAny = await _context.maritalStatuses.Where(e => e.Id == (candidate.MaritalStatus == null ? null : candidate.MaritalStatus.Id) || e.Code == CommonConstant.AnyCode).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateMaritalStatus", maritalStatusWithAny));

            matchFilterCondition.Add("(pot.\"OrganizationTypeId\" = any(@CandidateOrganizationType) or pot.\"OrganizationTypeId\" is null)");
            var organizationTypeWithAny = await _context.organizationTypes.Where(e => e.Id == (candidateProfessions.OrganizationType == null ? null : candidateProfessions.OrganizationType.Id) || e.Code == CommonConstant.AnyCode).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateOrganizationType", organizationTypeWithAny));


            matchFilterCondition.Add("(pc3.\"CreatedContactId\" =any(@CandidateCreator) or pc3.\"CreatedContactId\" is null)");
            var addressTypeWithAny = await _context.addressTypes.Where(e => e.Id == (candidate.CreatedContact == null ? null : candidate.CreatedContact.Id) || e.Code == CommonConstant.AnyCode).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateCreator", addressTypeWithAny));

            matchFilterCondition.Add("(pp.\"ProfessionId\" =any (@CandidateProfession) or pp.\"ProfessionId\" is null)");
            var professionWithAny = await _context.professions.Where(e => e.Id == (candidateProfessions.Profession == null ? null : candidateProfessions.Profession.Id) || e.Code == CommonConstant.AnyCode).Select(e => e.Id).ToListAsync();
            parameters.Add(new NpgsqlParameter("CandidateProfession", professionWithAny));


            LTree tpath = candidate?.ReligionTreePath;

            var religions = _context.religions
                           .Where(c => (tpath.IsDescendantOf(c.TreePath) && c.Type == ReligionConstants.SubCasteType) || c.Code == CommonConstant.AnyCode).Select(e => e.TreePath).ToList();

            matchFilterCondition.Add("(pr.\"ReligionTreePath\" = any (@religion) or pr.\"ReligionTreePath\" is null)");
            parameters.Add(new NpgsqlParameter("religion", religions));


            var nativeCountryWithAny = await _context.countries.Where(e => e.Code == CommonConstant.AnyCode || e.Id == (candidate.NativeCountry == null ? null : candidate.NativeCountry.Id)).AsNoTracking().Select(e => e.Id).ToListAsync();
            var workingCountryWithAny = await _context.countries.Where(e => e.Code == CommonConstant.AnyCode || e.Id == (candidateProfessions.WorkingCountry == null ? null : candidateProfessions.WorkingCountry.Id)).AsNoTracking().Select(e => e.Id).ToListAsync();

            var nativeStateWithAny = await _context.states.Where(e => e.Id == (candidate.NativeState == null ? null : candidate.NativeState.Id) || e.Code == CommonConstant.AnyCode).AsNoTracking().Select(e => e.Id).ToListAsync();
            var workingStateWithAny = await _context.states.Where(e => e.Id == (candidateProfessions.WorkingState == null ? null : candidateProfessions.WorkingState.Id) || e.Code == CommonConstant.AnyCode).AsNoTracking().Select(e => e.Id).ToListAsync();

            var nativedistrictWithAny = await _context.districts.Where(e => e.Id == (candidate.NativeDistrict == null ? null : candidate.NativeDistrict.Id) || e.Code == CommonConstant.AnyCode).AsNoTracking().Select(e => e.Id).ToListAsync();
            var workingdistrictWithAny = await _context.districts.Where(e => e.Id == (candidateProfessions.WorkingDistrict == null ? null : candidateProfessions.WorkingDistrict.Id) || e.Code == CommonConstant.AnyCode).AsNoTracking().Select(e => e.Id).ToListAsync();

            var nativetownWithAny = await _context.towns.Where(e => e.Id == (candidate.NativeTown == null ? null : candidate.NativeTown.Id) || e.Code == CommonConstant.AnyCode).AsNoTracking().Select(e => e.Id).ToListAsync();
            var workingtownWithAny = await _context.towns.Where(e => e.Id == (candidateProfessions.WorkingTown == null ? null : candidateProfessions.WorkingTown.Id) || e.Code == CommonConstant.AnyCode).AsNoTracking().Select(e => e.Id).ToListAsync();

            matchFilterCondition.Add("(pln2.\"CountryId\"= any (@CandidateNavtiveCountry) or pln2.\"CountryId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateNavtiveCountry", nativeCountryWithAny));

            matchFilterCondition.Add("(pl2.\"CountryId\"= any (@CandidateWorkingCountry) or pl2.\"CountryId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateWorkingCountry", workingCountryWithAny));

            matchFilterCondition.Add("(pl2.\"StateId\"= any (@CandidateWorkingState) or pl2.\"StateId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateWorkingState", workingStateWithAny));

            matchFilterCondition.Add("(pln2.\"StateId\"= any (@CandidateNavtiveState) or pln2.\"StateId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateNavtiveState", nativeStateWithAny));

            matchFilterCondition.Add("(pl2.\"DistrictId\"= any (@CandidateWorkingDistrict) or pl2.\"DistrictId\" is null )");
            parameters.Add(new NpgsqlParameter("CandidateWorkingDistrict", workingdistrictWithAny));

            matchFilterCondition.Add("(pln2.\"DistrictId\"= any (@CandidateNavtiveDistrict) or pln2.\"DistrictId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateNavtiveDistrict", nativedistrictWithAny));

            matchFilterCondition.Add("(pl2.\"TownId\"= any (@CandidateWorkingTown) or pl2.\"TownId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateWorkingTown", workingtownWithAny));

            matchFilterCondition.Add("(pln2.\"TownId\"= any (@CandidateNavtiveTown) or pln2.\"TownId\" is null)");
            parameters.Add(new NpgsqlParameter("CandidateNavtiveTown", nativetownWithAny));

            if (matchFilterCondition.Any())
            {
                query += "AND " + string.Join(" AND ", matchFilterCondition) + ")";
            }

            //query += "select *  from FinalResult";
            // query += "select c.*  from FinalResult c WHERE c.\"Id\" NOT IN (SELECT UNNEST(COALESCE(ARRAY_AGG(\"MatchCandidates\"), null))  FROM candidate_mail_match  WHERE  coalesce ( array_length(\"MatchCandidates\",1),0) !=0 AND \"CandidateId\" = @CandidateId)";
            query += "select c.*  from FinalResult c WHERE c.\"Id\" NOT IN (SELECT UNNEST(\"MatchCandidates\") FROM candidate_mail_match  WHERE  coalesce ( array_length(\"MatchCandidates\",1),0) !=0 AND \"CandidateId\" = @CandidateId)";

            return _context.candidatePartnerSearches.FromSqlRaw(query, parameters.ToArray());
        }
    }
}