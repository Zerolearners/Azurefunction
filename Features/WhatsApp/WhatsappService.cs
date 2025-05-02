using System.Text;
using ai_finder_be_schedulers_donetcore.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ai_finder_be_schedulers_donetcore.Features.WhatsApp;
public class WhatsappService
{
    private readonly FinderSetting finderSetting;
    public WhatsappService(FinderSetting finderSetting)
    {
        this.finderSetting = finderSetting;
    }
    private static readonly HttpClient client = new HttpClient();
    public async Task<string> TokenGenerationAsync()
    {
        string id;
        string url = finderSetting.WHATSAPP_TOKEN_GENERATION_API;
        string jsonPayload = finderSetting.WHATSAPP_PASSWORD;

        StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            dynamic final = JObject.Parse(result);
            id = final.idToken;
            return id;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
    }

    public async Task<HttpResponseMessage> SendTemplateAsync(string requestPayload, string token)
    {
        string postUrl = finderSetting.WHATSAPP_POST_API;
        string trimmedInput = requestPayload.Trim('{', '}');
        string[] pairs = trimmedInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var dictionary = new Dictionary<string, string>();

        foreach (string pair in pairs)
        {
            string[] keyValue = pair.Split(new[] { '=' }, 2);
            if (keyValue.Length == 2)
            {
                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim().Trim('"');
                dictionary[key] = value;
            }
        }

        var json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(postUrl, content);
            return response;
        }

    }
}
