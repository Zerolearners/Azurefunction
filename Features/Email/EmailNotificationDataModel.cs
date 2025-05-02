using System.ComponentModel.DataAnnotations;
using ai_finder_be_schedulers_donetcore.Common;

namespace ai_finder_be_schedulers_donetcore.Features.Email;
public class EmailNotificationDataModel
{

    public long Id { get; set; }
    public CandidateModel SenderCandidate { get; set; }
    public CandidateModel RecieverCandidate { get; set; }
    public ProductModel Product { get; set; }
    [Required]
    public NotificationCategoryModel Notification { get; set; }
    public string Template { get; set; }
    public EmailTemplateData Data { get; set; }
    public bool? IsSend { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ProcessedDateTime { get; set; }
    [Required]
    public string EmailId { get; set; }

}
