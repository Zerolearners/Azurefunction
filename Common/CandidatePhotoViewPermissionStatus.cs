namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidatePhotoViewPermissionStatus
    {
        public bool IsInterestSentOrAccepted { get; set; }
        public bool IsPhotoViewRequestAccepted { get; set; }
        public bool IsAlbumPhotoViewRequestAccepted { get; set; }
        public bool IsFamilyPhotoViewRequestAccepted { get; set; }
    }
}