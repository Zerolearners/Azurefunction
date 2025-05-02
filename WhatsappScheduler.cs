using ai_finder_be_schedulers_donetcore;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Features.WhatsApp;
using Microsoft.EntityFrameworkCore;
using ai_finder_be_schedulers_donetcore.Common;

namespace Company.Function
{
    public class WhatsappScheduler
    {
        private readonly ILogger _logger;
        private readonly FinderSchedulerDbContext _context;
        private readonly FinderSetting _setting;
        public WhatsappScheduler(ILoggerFactory loggerFactory, FinderSchedulerDbContext context, FinderSetting setting)
        {
            _logger = loggerFactory.CreateLogger<WhatsappScheduler>();
            _context = context;
            _setting = setting;
        }

        // [Function("WhatsappScheduler")]  test
        public async Task Run([TimerTrigger("0 */2 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"WhatsappScheduler function executed at: {DateTime.Now}");

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
            var whatsapps = await _context.Whatsapps.Where(e => e.IsSend == false).Include(n => n.Notification).OrderBy(e => e.Id).ToListAsync();
            foreach (var whatsapp in whatsapps)
            {
                await SendWhatsapp(whatsapp);
            }
            if (whatsapps.Count() > 0)
            {
                SchedulerRunBookModel schedulerRunBooks = new SchedulerRunBookModel();
                schedulerRunBooks.ProcessStartTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Status = "Success";
                schedulerRunBooks.ProcessEndTime = DateTime.Now.ToUniversalTime();
                schedulerRunBooks.Notification = whatsapps.Select(e => e.Notification).FirstOrDefault();//Email || sms
                schedulerRunBooks.BatchStart = whatsapps.Select(e => e.Id).FirstOrDefault();
                schedulerRunBooks.BatchEnd = whatsapps.Select(e => e.Id).LastOrDefault();
                _context.Add(schedulerRunBooks);
                _context.SaveChanges();
            }
        }
        public async Task SendWhatsapp(WhatsappNotificationDataModel whatsappNotificationDataModel)
        {
            WhatsappTemplateManager _whatsappTemplateManager = new WhatsappTemplateManager(_setting);
            string WhatsAppTemplateUrl = WhatsappConstant.WhatsAppTemplateUrl + whatsappNotificationDataModel.Template;
            var whatsappData = _whatsappTemplateManager.GetWhatsappTemplate(WhatsAppTemplateUrl, whatsappNotificationDataModel);

            WhatsappService _whatsappService = new WhatsappService(_setting);
            string token = await _whatsappService.TokenGenerationAsync();
            var whatsappResponse = await _whatsappService.SendTemplateAsync(whatsappData, token);
            if (whatsappResponse.IsSuccessStatusCode)
            {
                whatsappNotificationDataModel.ProcessedDateTime = DateTime.Now.ToUniversalTime();
                whatsappNotificationDataModel.IsSend = true;
                await _context.SaveChangesAsync();
            }
        }

    }
}