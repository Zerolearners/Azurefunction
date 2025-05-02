using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common;

public class AlertGroupsModel
{
    public long Id { get; set; }
    [Required]
    public NameInLanguageModel Name { get; set; }
    public Guid Code { get; set; }
    public bool IsDisplayInEmail { get; set; }
    public bool IsDisplayInSms { get; set; }
    public bool IsDisplayInWhatsapp { get; set; }
    public bool IsDisplayInPushNotification { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
