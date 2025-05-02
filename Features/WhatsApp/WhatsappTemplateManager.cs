using System.Text.RegularExpressions;
using ai_finder_be_schedulers_donetcore.Common;
using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Constants;

namespace ai_finder_be_schedulers_donetcore.Features.WhatsApp;

public class WhatsappTemplateManager
{
    private readonly FinderSetting finderSettings;
    Random rnd = new Random();
    public WhatsappTemplateManager(FinderSetting finderSetting)
    {
        this.finderSettings = finderSetting;
    }
    public string GetWhatsappTemplate(string filePath, WhatsappNotificationDataModel data)
    {
        var templateData = data.Data;
        string template = File.ReadAllText(filePath);
        string[] templateName = data.Template.Split('.');
        int num = rnd.Next();

        template = template.Replace(WhatsappTemplateConstants.From, finderSettings.WHATSAPP_NUMBER);
        template = template.Replace(WhatsappTemplateConstants.To, data.PhoneNumber.CountryCode.ToString() + data.PhoneNumber.Number.ToString());
        template = template.Replace(WhatsappTemplateConstants.Language, finderSettings.WHATSAPP_LANGUAGE);
        template = template.Replace(WhatsappTemplateConstants.MessageId, num.ToString());
        template = template.Replace(WhatsappTemplateConstants.TemplateName, templateName[0]);

        template = template.Replace(WhatsappTemplateConstants.Param1, templateData.TaggedName);
        template = template.Replace(WhatsappTemplateConstants.Param2, templateData.TaggedProfileId);
        template = template.Replace(WhatsappTemplateConstants.Param3, templateData.Username);
        template = template.Replace(WhatsappTemplateConstants.Param4, templateData.Message);
        template = template.Replace(WhatsappTemplateConstants.Param5, templateData.Reason);
        template = template.Replace(WhatsappTemplateConstants.ParameterCount, templateData.ParameterCount);
        template = Regex.Replace(template, @"\s+", "");
        return template;
    }
}
