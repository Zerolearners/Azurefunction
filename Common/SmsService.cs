using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Constants;

namespace ai_finder_be_schedulers_donetcore.Common;

public class SmsService
{
    private readonly FinderSetting finderSetting;
    private readonly Response response;
    public SmsService(FinderSetting finderSetting)
    {
        this.finderSetting = finderSetting;
        response = new Response();
    }
    public async Task<ResponseDTO> SendSMS(SmsRequestData requestData)
    {
        // Base64 encoded credentials for Basic Authorization
        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{finderSetting.SMS_API_USERNAME}:{finderSetting.SMS_API_PASSWORD}"));

        // Create an instance of HttpClient
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(finderSetting.SMS_API_AUTH_TYPE, credentials);
        client.DefaultRequestHeaders.Add(SmsConstant.SmsHeaderKeyName, finderSetting.SMS_API_KEY);

        var sendResponse = await client.PostAsJsonAsync(finderSetting.SMS_SEND_POST_API, requestData);

        return sendResponse.IsSuccessStatusCode ? response.GetCommonSuccessResponse(null) : response.GetCommonFailureResponse(SmsConstant.SendFailed);
    }
    public SmsRequestData GetSmsContent(string mobileNumber, string message, string templateId, string entityId)
    {
        if (finderSetting.ENVIRONMENT_NAME != ConfigurationConstant.IsProduction) { mobileNumber = finderSetting.DEFAULT_RECEIVER_MOBILE; }
        return new SmsRequestData
        {
            MessageContent = message,
            Senderid = finderSetting.SMS_SENDER_ID,
            TemplateId = templateId,
            Destination = mobileNumber,
            EntityId = entityId,
            CountryCode = ContactInformations.IndiaCountryCode.ToString()
        };
    }
    public MessageDataConfiguration GetSmsTemplate(MessageDataConfiguration template, SmsTemplateData data)
    {
        // string template =filePath ;//File.ReadAllText(filePath);
        template.Message = template.Message.Replace(SmsConstant.TaggedName, data.TaggedName);//receiver name
        template.Message = template.Message.Replace(SmsConstant.TaggedProfileId, data.TaggedProfileId?.ToString());//receiver chavaraid
        template.Message = template.Message.Replace(SmsConstant.Username, data.Username);//sender name
        template.Message = template.Message.Replace(SmsConstant.UserChavaraId, data.ChavaraId);//sender chavaraid
        template.Message = template.Message.Replace(SmsConstant.ExpiryInDays, data.ExpiryInDays);
        template.Message = template.Message.Replace(SmsConstant.ExpiryDate, data.ExpiryDate);
        template.Message = template.Message.Replace(SmsConstant.Hidden, data.Hidden);
        template.Message = template.Message.Replace(SmsConstant.Membership, data.Membership);
        template.Message = template.Message.Replace(SmsConstant.Month, data.Month);
        template.Message = template.Message.Replace(SmsConstant.Year, data.Edition);
        return template;
    }
}
