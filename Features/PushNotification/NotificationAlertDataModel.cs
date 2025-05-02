using System.ComponentModel.DataAnnotations;
using ai_finder_be_schedulers_donetcore.Common;

namespace ai_finder_be_schedulers_donetcore.Features.PushNotification
{
    public class NotificationAlertDataModel
    {
        public long Id { get; set; }
        [Required]
        public NotificationCategoryModel NotificationCategory { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        public AlertData AlertData { get; set; }
        public PushData PushData { get; set; }
        [Required]
        public LookupSettingModel Status { get; set; }
        public LookupSettingModel ReadSource { get; set; }
        public DeviceInformationModel DeviceInformation { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        public DateTime? ExpiryTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }
    }
}