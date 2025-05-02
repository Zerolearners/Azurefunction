using ai_finder_be_schedulers_donetcore;
using ai_finder_be_schedulers_donetcore.Common;
using ai_finder_be_schedulers_donetcore.Configuration;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class DiamondPlusMemberShip
    {

        private readonly ILogger _logger;
        private readonly FinderSchedulerDbContext _context;
        private readonly FinderSetting _setting;
        private readonly IMatches matches;
        private readonly MailSetting _mailsetting;
        public DiamondPlusMemberShip(ILoggerFactory loggerFactory, FinderSchedulerDbContext context, FinderSetting setting, IMatches matches, MailSetting mailSetting)
        {
            _logger = loggerFactory.CreateLogger<DiamondPlusMemberShip>();
            _context = context;
            _setting = setting;
            _mailsetting = mailSetting;
            this.matches = matches;
        }
        [Function("DiamondPlusMemberShip")]// 2 am will start
        public async Task Run([TimerTrigger("30 20 * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"DiamondMemberShip function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                try
                {
                    EmailService emailService = new EmailService(_mailsetting, _context, _setting);

                    // var membership = await _context.subscriptions.Include(e => e.SubscriptionCategory).Where(e => e.SubscriptionCategory.Code == CommonConstant.PremiumMembers && e.IsActive && e.IsSearchable).ToListAsync();
                    //var membershipCodes = membership.Select(e => e.Code).ToArray();
                    string[] membershipCodes = new string[] { CommonConstant.DiamondPlusCode };
                    var candidateDetailsForEmail = await matches.SendPushData(membershipCodes);

                    var pageInfo = await _context.Pageinfo.Where(e => e.HashCode == "fad225e6-7eac-4fc3-bdc1-66ed6b5ac0f3").Select(e => e.Url).FirstOrDefaultAsync();
                    var pageInfoUnsubscribe = await _context.Pageinfo.Where(e => e.HashCode == "da2adc74-de8f-49d7-99fa-54d0a4541ded").Select(e => e.Url).FirstOrDefaultAsync();
                    var pageInfoPolicyMapping = await _context.Pageinfo.Where(e => e.HashCode == "6bcae392-7fb5-4e7f-b321-1ec4ce490a37").Select(e => e.Url).FirstOrDefaultAsync();

                    foreach (var candidates in candidateDetailsForEmail)
                    {
                        var candidateDetailsList = await matches.CandidateSearchByMyMatchV2(candidates.candidate.Id, candidates.candidate.Gender.Id, membershipCodes);
                        if (candidateDetailsList.Count > 0)
                        {
                            var getNotificationDetails = await _context.notificationCategories.Where(e => candidates.subscription.Code == CommonConstant.CelestialCode ? e.Code.ToString() == CommonConstant.WishlistForCelestialMember : e.Code.ToString() == CommonConstant.WishlistForNormalMember).FirstOrDefaultAsync();

                            var htmlBinder = emailService.HtmBuilder(candidates?.subscription?.Code, candidateDetailsList, pageInfo);
                            var selectTemplate = emailService.SelectTemplateBasedOnSubscription(htmlBinder, getNotificationDetails?.EmailTemplateUrl, candidates, pageInfoUnsubscribe, pageInfoPolicyMapping);
                            var getMailContent = emailService.GetMailContentForWishlist(candidates.candidateContact.Email.EmailId, getNotificationDetails?.Name, selectTemplate);

                            List<long> dataArray = candidateDetailsList.Select(item => item.Id).ToList();
                            long[] dataArrayAsArray = dataArray.ToArray();

                            var mailSendResponse = await emailService.SendMail(getMailContent, null, getNotificationDetails, candidates.candidate, null, dataArrayAsArray, null);
                        }
                    }

                    _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message.ToString());
                }
            }
        }
    }
}