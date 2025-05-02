using ai_finder_be_schedulers_donetcore.Configuration;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace ai_finder_be_schedulers_donetcore.Features.PushNotification
{
    public class NotificationService
    {
        private readonly FinderSchedulerDbContext dbContext;
        private readonly FinderSetting finderSetting;
        public NotificationService(FinderSchedulerDbContext dbContext, FinderSetting finderSetting)
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(finderSetting.FIREBASE_SERVICE_ACCOUNT_INFO)
                });
            }
            this.dbContext = dbContext;
            this.finderSetting = finderSetting;
        }

        public async Task SendPushNotification(List<string> tokens, FirebaseAdmin.Messaging.Message message)
        {
            var messageList = tokens
                .Select(x => new FirebaseAdmin.Messaging.Message
                {
                    Token = x,
                    Notification = message.Notification,
                    Data = message.Data
                })
                .ToList();

            if (messageList.Any()) await FirebaseMessaging.DefaultInstance.SendEachAsync(messageList);
        }

        public IReadOnlyDictionary<string, string> GetNotificationDataReadOnlyDictionary(PushnotificationData pushNotificationData)
        {
            IReadOnlyDictionary<string, string> notificationDictionary = new Dictionary<string, string>{
            { nameof(pushNotificationData.CandidateId), pushNotificationData.CandidateId.ToString() },
            {nameof(pushNotificationData.NotificationId), pushNotificationData.NotificationId?.ToString()},
            { nameof(pushNotificationData.SourcePageCode), pushNotificationData.SourcePageCode },
            { nameof(pushNotificationData.GroupCode), pushNotificationData.GroupCode },
            { nameof(pushNotificationData.IsSound), pushNotificationData.IsSound.ToString()}
        };

            return notificationDictionary;
        }
    }
}