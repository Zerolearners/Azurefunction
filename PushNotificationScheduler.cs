using ai_finder_be_schedulers_donetcore;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ai_finder_be_schedulers_donetcore.Configuration;
using Microsoft.EntityFrameworkCore;
using ai_finder_be_schedulers_donetcore.Features.PushNotification;
using FirebaseAdmin.Messaging;
using ai_finder_be_schedulers_donetcore.Common;

namespace Company.Function
{
    public class PushNotificationScheduler
    {
        private readonly ILogger _logger;
        private readonly FinderSchedulerDbContext _context;
        private readonly FinderSetting _finderSettings;

        public PushNotificationScheduler(ILoggerFactory loggerFactory, FinderSchedulerDbContext context, FinderSetting finderSetting)
        {
            _logger = loggerFactory.CreateLogger<PushNotificationScheduler>();
            _context = context;
            _finderSettings = finderSetting;
        }

        [Function("PushNotificationScheduler")]
        public async Task Run([TimerTrigger("30 23 * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"PushNotificationScheduler function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                try
                {
                    await SendPushData();
                    _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message.ToString());
                }
            }
        }

        public async Task SendPushData()
        {
            NotificationService notificationService = new NotificationService(_context, _finderSettings);

            var lookupData = _context.LookupSettings.Include(e => e.LookupType).Where(e => e.LookupType.Code == "70b0df21-6911-49c3-8df9-9e30a9cbe4c0" && e.IsActive).ToList();
            var lookupNotSendData = lookupData.FirstOrDefault(e => e.Code == "4f0c4c88-6363-4845-aaf9-bb1da76f824a");
            var lookupSendData = lookupData.FirstOrDefault(e => e.Code == "54566ea5-31ec-478a-8520-0ada469d78c6");

            var pushData = await _context.NotificationAlertDatas.Where(e => e.Status == lookupNotSendData && e.PushData != null).Include(e => e.Candidate).Include(e => e.NotificationCategory).ToListAsync();

            foreach (var push in pushData)
            {
                var users = _context.loginInformations.Where(e => e.Candidate == push.Candidate).Include(e => e.DeviceInformation).Where(e => e.DeviceInformation.FirebaseToken != null).Select(d => d.DeviceInformation.FirebaseToken).ToList();

                var message = new FirebaseAdmin.Messaging.Message
                {
                    Notification = new Notification
                    {
                        Title = push.PushData.Title,
                        Body = push.PushData.Body
                    },
                    Data = notificationService.GetNotificationDataReadOnlyDictionary(push.PushData.Data)
                };

                await notificationService.SendPushNotification(users, message);

            }

            await updateNotificationAlertData(pushData, lookupSendData);

            if (pushData.Count() > 0)
            {
                SchedulerRunBookModel schedulerRunBooks = new SchedulerRunBookModel();
                schedulerRunBooks.ProcessStartTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Status = "Success";
                schedulerRunBooks.ProcessEndTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Notification = pushData.Select(e => e.NotificationCategory).FirstOrDefault();//Email||sms||push||whatsapp
                schedulerRunBooks.BatchStart = pushData.Select(e => e.Id).FirstOrDefault();
                schedulerRunBooks.BatchEnd = pushData.Select(e => e.Id).LastOrDefault();

                _context.Add(schedulerRunBooks);
                _context.SaveChanges();
            }
        }
        public async Task updateNotificationAlertData(List<NotificationAlertDataModel> notificationAlertDataModel, LookupSettingModel lookupSettingModel)
        {
            foreach (var notificationAlertData in notificationAlertDataModel)
            {
                notificationAlertData.Status = lookupSettingModel;
                await updateNotificationAlertDataDetails(lookupSettingModel, notificationAlertData);
            }

            await _context.SaveChangesAsync();
        }
        public async Task updateNotificationAlertDataDetails(LookupSettingModel lookupSettingModel, NotificationAlertDataModel notificationAlertDataModel)
        {
            var loginInformations = await _context.loginInformations.Where(e => e.Candidate.Id == notificationAlertDataModel.Candidate.Id).Include(e => e.DeviceInformation).ToListAsync();

            foreach (var loginInformation in loginInformations)
            {
                var notificationAlertDataDetailsModel = new NotificationAlertDataDetailsModel
                {
                    NotificationAlertData = notificationAlertDataModel,
                    Status = lookupSettingModel,
                    DeviceInformation = loginInformation.DeviceInformation
                };

                _context.Add(notificationAlertDataDetailsModel);
            }
        }
    }
}