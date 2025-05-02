using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidatePhotoModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        [Required]
        public PhotoTypeModel Type { get; set; }
        public string SourceFileUrl { get; set; }
        public string DisplayPhotoUrl { get; set; }
        public string ThumbnailPhotoUrl { get; set; }
        public string NoWaterMarkDisplayPhotoUrl { get; set; }
        public string BlurredPhotoUrl { get; set; }
        public int Order { get; set; }
        public bool? IsVisible { get; set; }
        public PhotoPrivacyPolicyTypeModel PrivacyPolicyType { get; set; }
        public string PhotoPassword { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public List<AuditPropertyModel> AuditProperty { get; set; }
        public string MigrationTableName { get; set; }
        public long? MigrationId { get; set; }
        public ProductModel Source { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}