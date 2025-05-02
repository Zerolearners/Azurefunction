using ai_finder_be_schedulers_donetcore.Common;

namespace ai_finder_be_schedulers_donetcore.Features.WhatsApp;

public class WhatsappNotificationDataModel
{
    public long Id { get; set; }

    public NotificationCategoryModel Notification { get; set; }
    public string Template { get; set; }
    public WhatsappTemplateData Data { get; set; }
    public bool? IsSend { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ProcessedDateTime { get; set; }

    public MobileNumberModelDTO PhoneNumber { get; set; }
}
