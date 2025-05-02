namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateContactModel
    {
        public long Id { get; set; }
        public CandidateModel Candidate { get; set; }
        public AddressTypeModel Type { get; set; }
        public string Name { get; set; }
        public LandLineModel LandPhone { get; set; }
        public bool IsLandPhoneValidated { get; set; }
        public MobileNumberModelDTO MobilePhone { get; set; }
        public bool IsMobilePhoneValidated { get; set; }
        public MobileNumberModelDTO WhatsApp { get; set; }
        public bool IsWhatsAppValidated { get; set; }
        public EmailModel Email { get; set; }
        public bool IsEmailValidated { get; set; }
        public string Pincode { get; set; }
        public bool IsPincodeValidated { get; set; }
        public List<AddressInfo> Address { get; set; }
        public long? ReferenceAddressId { get; set; }
        public string Relation { get; set; }
        public string PreferredTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}