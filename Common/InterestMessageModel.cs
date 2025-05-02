using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class InterestMessageModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel SenderCandidate { get; set; }
        [Required]
        public CandidateModel ReceiverCandidate { get; set; }
        [Required]
        public MessageCategoryModel MessageCategory { get; set; }
        public MessageModel Message { get; set; }
        public string CustomMessage { get; set; }
        [Required]
        public MessageStatusModel MessageStatus { get; set; }
        public string GroupCode { get; set; }
        public bool? IsReaded { get; set; }
        public bool? IsSenderStarred { get; set; }
        public bool? IsReceiverStarred { get; set; }
        public bool? IsSenderTrashed { get; set; }
        public bool? IsReceiverTrashed { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? IsWithdraw { get; set; }
        public bool? IsSenderDeleted { get; set; }
        public bool? IsReceiverDeleted { get; set; }
        public bool? IsRespondLater { get; set; }
        public List<AuditPropertyModel> AuditProperty { get; set; }
        public long MigrationId { get; set; }
        public bool? IsAdminSenderDeleted { get; set; }
        public bool? IsAdminReceiverDeleted { get; set; }
        public UserModel User { get; set; }
    }
}