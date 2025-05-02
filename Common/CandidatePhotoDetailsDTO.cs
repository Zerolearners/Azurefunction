namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidatePhotoDetailsDTO
    {
        public long? Id { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public long? PrivacyPolicyId { get; set; }
        public string DisplayPhotoUrl { get; set; }
        public string ThumbnailPhotoUrl { get; set; }
        public string SourcePhotoUrl { get; set; }
        public string PrivacyCode { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsPhotoAvailable { get; set; }
        public PhotoRequestInfoDTO PhotoRequestInfo { get; set; }
    }
}