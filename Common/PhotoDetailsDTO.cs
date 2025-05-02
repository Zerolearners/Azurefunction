namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PhotoDetailsDTO
    {
        public long? TotalCount { get; set; }
        public List<CandidatePhotoDetailsDTO> CandidatePhotos { get; set; }
    }
}