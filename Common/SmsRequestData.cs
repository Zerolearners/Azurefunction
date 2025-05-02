namespace ai_finder_be_schedulers_donetcore.Common;

public class SmsRequestData
{
    public string MessageContent { get; set; }
    public string Senderid { get; set; }
    public string TemplateId { get; set; }
    public string Destination { get; set; }
    public string EntityId { get; set; }
    public string CountryCode { get; set; }
}
