namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PhotoDTO
    {
        public string Type { get; set; }
        public long? Id { get; set; }
        public int Order { get; set; }
        public string DisplayPhotoUrl { get; set; }
        public string ThumbnailPhotoUrl { get; set; }
        public string NoWaterMarkDisplayPhotoUrl { get; set; }
        public bool? IsVerified { get; set; }
        public string PrivacyCode { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? ArchivedTimeStamp { get; set; }
        public PhotoRequestInfoDTO PhotoRequestInfo { get; set; }
    }
}