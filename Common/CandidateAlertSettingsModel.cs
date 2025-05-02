using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateAlertSettingsModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        [Required]
        public AlertGroupsModel Alert { get; set; }
        public bool IsSms { get; set; }
        public bool IsEmail { get; set; }
        public bool IsWhatsapp { get; set; }
        public bool IsPushNotification { get; set; }
        public bool IsSound { get; set; }
        public bool IsDeleted { get; set; }
        public List<AuditPropertyModel> AuditProperty { get; set; }
    }
}