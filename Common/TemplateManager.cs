using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Constants;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class TemplateManager
    {
        private readonly FinderSetting _finderSettings;
        private readonly MailSetting _mailsetting;
        private readonly FinderSchedulerDbContext _context;
        public TemplateManager(FinderSetting finderSetting, MailSetting mailSetting, FinderSchedulerDbContext context)
        {
            _finderSettings = finderSetting;
            _mailsetting = mailSetting;
            _context = context;
        }
        public string GetMailTemplate(string filePath, EmailTemplateData data)
        {
            EmailService emailService = new EmailService(_mailsetting, _context, _finderSettings);
            string template = File.ReadAllText(filePath);

            template = template.Replace(HtmlTemplateConstant.TaggedName, data.TaggedName);//receiver name
            template = template.Replace(HtmlTemplateConstant.TaggedProfileId, data.TaggedProfileId);//receiver chavaraid
            template = template.Replace(HtmlTemplateConstant.Username, data.Username);//sender name
            template = template.Replace(HtmlTemplateConstant.UserChavaraId, data.UserChavaraId);//sender chavaraid
            template = template.Replace(HtmlTemplateConstant.PhotoUrl, (data.PhotoUrl == null ? (data.Gender == "M" ? _finderSettings.FINDER_PHOTOS_BASE_URL + _finderSettings.NO_IMAGE_MALE_URL : _finderSettings.FINDER_PHOTOS_BASE_URL + _finderSettings.NO_IMAGE_FEMALE_URL) : _finderSettings.FINDER_PHOTOS_BASE_URL + _finderSettings.PROFILE_PHOTO_BASE_URL + data.PhotoUrl));
            // template = template.Replace(HtmlTemplateConstant.PhotoUrl, (data.PhotoUrl == null ? (data.Gender == "M" ? _finderSettings.BASE_URL + _finderSettings.NO_IMAGE_MALE_URL : _finderSettings.BASE_URL + _finderSettings.NO_IMAGE_FEMALE_URL) : _finderSettings.BASE_URL + _finderSettings.PROFILE_PHOTO_BASE_URL + data.PhotoUrl));
            template = template.Replace(HtmlTemplateConstant.MailId, data.MailId);
            template = template.Replace(HtmlTemplateConstant.Subject, data.Subject);
            template = template.Replace(HtmlTemplateConstant.DateTime, data.DateTime);
            template = template.Replace(HtmlTemplateConstant.PhotoType, data.PhotoType);
            //sender details
            template = template.Replace(HtmlTemplateConstant.Message, data.Message);
            template = template.Replace(HtmlTemplateConstant.Age, data.Age?.ToString());
            template = template.Replace(HtmlTemplateConstant.ExpiryInDays, data.ExpiryInDays.ToString());
            template = template.Replace(HtmlTemplateConstant.Height, data.Height?.ToString());
            template = template.Replace(HtmlTemplateConstant.MaritalStatus, data.MaritalStatus);
            template = template.Replace(HtmlTemplateConstant.Denomination, data.Denomination);
            template = template.Replace(HtmlTemplateConstant.Education, data.Education);
            template = template.Replace(HtmlTemplateConstant.Profession, data.Profession);
            template = template.Replace(HtmlTemplateConstant.WorkPlace, data.WorkPlace);
            template = template.Replace(HtmlTemplateConstant.Membership, data.Membership);
            template = template.Replace(HtmlTemplateConstant.ExpiryDate, data.ExpiryDate);
            template = template.Replace(HtmlTemplateConstant.Month, data.Month);
            template = template.Replace(HtmlTemplateConstant.Year, data.Year);
            template = template.Replace(HtmlTemplateConstant.Edition, data.Edition);
            template = template.Replace(HtmlTemplateConstant.MagazineCoverPhoto, _finderSettings.FINDER_PHOTOS_BASE_URL + _finderSettings.FINDER_MAGAZINE_COVER_URL + data.MagazineCoverPhoto);
            //button
            template = template.Replace(HtmlTemplateConstant.AcceptButton, _finderSettings.FINDER_BASE_URL + data.AcceptButton);
            template = template.Replace(HtmlTemplateConstant.DeclineButton, _finderSettings.FINDER_BASE_URL + data.DeclineButton);
            template = template.Replace(HtmlTemplateConstant.FullProfileButton, _finderSettings.FINDER_BASE_URL + data.FullProfileButton + emailService.GetEncriptionUrl(Convert.ToString(data.UserId)));
            template = template.Replace(HtmlTemplateConstant.PhotoUploadRequestButton, _finderSettings.FINDER_BASE_URL + data.PhotoUploadRequestButton);
            template = template.Replace(HtmlTemplateConstant.PhotoViewRequestApproveButton, _finderSettings.FINDER_BASE_URL + data.PhotoViewRequestApproveButton);
            template = template.Replace(HtmlTemplateConstant.More, _finderSettings.FINDER_BASE_URL + data.More);
            template = template.Replace(HtmlTemplateConstant.Upgrade, _finderSettings.FINDER_BASE_URL + data.Upgrade);
            template = template.Replace(HtmlTemplateConstant.SuccessStoryUrl, _finderSettings.FINDER_BASE_URL + data.SuccessStoryUrl);
            template = template.Replace(HtmlTemplateConstant.UnSubscribe, _finderSettings.FINDER_BASE_URL + data.UnSubscribe + emailService.GetEncriptionUrl(Convert.ToString(data.UnSubscribeChavaraId)));
            template = template.Replace(HtmlTemplateConstant.WebsiteUrl, _finderSettings.FINDER_BASE_URL);

            return template;
        }
    }
}