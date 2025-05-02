using ai_finder_be_schedulers_donetcore;
using ai_finder_be_schedulers_donetcore.Common;
using ai_finder_be_schedulers_donetcore.Features.Email;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Constants;

namespace Company.Function
{
    public class EmailScheduler
    {
        private readonly ILogger _logger;
        private readonly FinderSchedulerDbContext _context;
        private readonly MailSetting _mailsetting;

        private readonly FinderSetting _finderSetting;
        public EmailScheduler(ILoggerFactory loggerFactory, FinderSchedulerDbContext context, MailSetting mailsetting, FinderSetting finderSetting)
        {
            _logger = loggerFactory.CreateLogger<EmailScheduler>();
            _context = context;
            _mailsetting = mailsetting;
            _finderSetting = finderSetting;
        }

        [Function("EmailScheduler")]
        public async Task Run([TimerTrigger("30 23 * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"EmailScheduler function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                try
                {
                    await SendEmailData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message.ToString());
                }
            }
        }
        public async Task SendEmailData()
        {
            var emails = await _context.EmailNotificationDatas.Where(e => e.IsSend == false && e.EmailId != "" && e.EmailId != null).Include(n => n.Notification).OrderBy(e => e.Id).ToListAsync();
            foreach (var email in emails)
            {
                await SendEmail(email);
            }
            if (emails.Count() > 0)
            {
                SchedulerRunBookModel schedulerRunBooks = new SchedulerRunBookModel();
                schedulerRunBooks.ProcessStartTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Status = "Success";
                schedulerRunBooks.ProcessEndTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Notification = emails.Select(e => e.Notification).FirstOrDefault();//Email || sms
                schedulerRunBooks.BatchStart = emails.Select(e => e.Id).FirstOrDefault();
                schedulerRunBooks.BatchEnd = emails.Select(e => e.Id).LastOrDefault();
                _context.Add(schedulerRunBooks);
                _context.SaveChanges();
            }
        }
        public async Task SendEmail(EmailNotificationDataModel emailNotificationDataModel)
        {
            EmailService emailService = new EmailService(_mailsetting, _context, _finderSetting);
            string emailTemplateUrl = HtmlTemplateConstant.EmailTemplateUrl + emailNotificationDataModel.Template;

            var mailData = emailService.GetMailContent(emailNotificationDataModel.EmailId, emailNotificationDataModel.Data.Subject, emailTemplateUrl, emailNotificationDataModel.Data);
            var mailSendResponse = emailService.SendMail(mailData);
            if (mailSendResponse.Success)
            {
                emailNotificationDataModel.ProcessedDateTime = DateTime.Now.ToUniversalTime();
                emailNotificationDataModel.IsSend = true;
                // await _context.SaveChangesAsync();
            }
        }
    }
}