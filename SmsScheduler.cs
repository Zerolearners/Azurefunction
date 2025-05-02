using ai_finder_be_schedulers_donetcore;
using ai_finder_be_schedulers_donetcore.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ai_finder_be_schedulers_donetcore.Features.Sms;
using ai_finder_be_schedulers_donetcore.Configuration;
using System.Text.Json;

namespace Company.Function
{
    public class SmsScheduler
    {
        private readonly ILogger _logger;
        private readonly FinderSchedulerDbContext _context;
        private readonly FinderSetting _setting;
        public SmsScheduler(ILoggerFactory loggerFactory, FinderSchedulerDbContext context, FinderSetting setting)
        {
            _logger = loggerFactory.CreateLogger<SmsScheduler>();
            _context = context;
            _setting = setting;
        }

        [Function("SmsScheduler")]
        public async Task Run([TimerTrigger("30 23 * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"SmsScheduler function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                try
                {
                    await SendSmsData();
                    _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message.ToString());
                }
            }
        }
        public async Task SendSmsData()
        {
            var smsData = await _context.Sms.Where(e => e.IsSend == false && e.Template.TemplateId != null).Include(n => n.Notification).OrderBy(e => e.Id).ToListAsync();
            foreach (var sms in smsData)
            {
                await SendSms(sms);
            }

            if (smsData.Count() > 0)
            {
                SchedulerRunBookModel schedulerRunBooks = new SchedulerRunBookModel();
                schedulerRunBooks.ProcessStartTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Status = "Success";
                schedulerRunBooks.ProcessEndTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Notification = smsData.Select(e => e.Notification).FirstOrDefault();
                schedulerRunBooks.BatchStart = smsData.Select(e => e.Id).FirstOrDefault();
                schedulerRunBooks.BatchEnd = smsData.Select(e => e.Id).LastOrDefault();

                _context.Add(schedulerRunBooks);
                _context.SaveChanges();
            }
        }
        public async Task SendSms(SmsNotificationDataModel smsNotificationDataModel)
        {
            SmsService _smsService = new SmsService(_setting);

            MessageDataConfiguration messageDataConfiguration = _smsService.GetSmsTemplate(smsNotificationDataModel.Template, smsNotificationDataModel.Data);

            SmsRequestData smsRequestData = _smsService.GetSmsContent(smsNotificationDataModel?.PhoneNumber?.Number.ToString(), messageDataConfiguration.Message, messageDataConfiguration.TemplateId, messageDataConfiguration.Entity);

            var smsSendResponse = await _smsService.SendSMS(smsRequestData);
            if (smsSendResponse.Success)
            {
                smsNotificationDataModel.ProcessedDateTime = DateTime.Now.ToUniversalTime();
                smsNotificationDataModel.IsSend = true;
                // await _context.SaveChangesAsync();
            }
        }
    }
}