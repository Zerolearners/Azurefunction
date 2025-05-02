
using ai_finder_be_schedulers_donetcore.Common;

namespace ai_finder_be_schedulers_donetcore.Features.Sms;

public class SmsNotificationDataModel
{
    public long Id { get; set; }

    public NotificationCategoryModel Notification { get; set; }
    public MessageDataConfiguration Template { get; set; }
    public SmsTemplateData Data { get; set; }
    public bool? IsSend { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ProcessedDateTime { get; set; }

    public MobileNumberModelDTO PhoneNumber { get; set; }
}
