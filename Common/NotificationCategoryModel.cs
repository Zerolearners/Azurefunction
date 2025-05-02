using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common;

public class NotificationCategoryModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    [Required]
    public AlertGroupsModel Alert { get; set; }
    public bool IsEmail { get; set; }
    public bool IsSms { get; set; }
    public bool IsWhatsapp { get; set; }
    public bool IsPushNotification { get; set; }
    public string? SmsTemplate { get; set; }
    public string? WhatsappTemplateUrl { get; set; }
    public string? EmailTemplateUrl { get; set; }
    public string? PushNotificationTemplate { get; set; }
    public Guid Code { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
