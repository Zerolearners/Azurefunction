using System.ComponentModel.DataAnnotations;
using ai_finder_be_schedulers_donetcore.Common;

namespace ai_finder_be_schedulers_donetcore.Features.PushNotification
{
    public class NotificationAlertDataDetailsModel
    {
        public long Id { get; set; }
        [Required]
        public NotificationAlertDataModel NotificationAlertData { get; set; }
        [Required]
        public LookupSettingModel Status { get; set; }
        public LookupSettingModel ReadSource { get; set; }
        public DeviceInformationModel DeviceInformation { get; set; }
        public DateTime? ReadTimeStamp { get; set; }
    }
}