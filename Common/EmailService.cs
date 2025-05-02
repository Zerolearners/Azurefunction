using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Constants;
using ai_finder_be_schedulers_donetcore.Features.Email;
using ai_finder_be_schedulers_donetcore.Features.MyMatches;
namespace ai_finder_be_schedulers_donetcore.Common;
public class EmailService
{
  SmtpClient smtpClient;
  private readonly MailSetting mailSetting;
  private readonly FinderSchedulerDbContext dbContext;

  private readonly FinderSetting finderSetting;

  Response response;

  public EmailService(MailSetting mailSetting, FinderSchedulerDbContext dbContext, FinderSetting finderSetting)
  {
    this.mailSetting = mailSetting;
    this.dbContext = dbContext;
    this.finderSetting = finderSetting;
    ConfigureSmtpClient();
    response = new Response();
  }

  private void ConfigureSmtpClient()
  {
    smtpClient = new SmtpClient(mailSetting.SERVER_NAME);
    smtpClient.Port = mailSetting.EMAIL_PORT_NUMBER;
    smtpClient.Credentials = new NetworkCredential(mailSetting.MAIL_USERNAME, mailSetting.MAIL_PASSWORD);
    smtpClient.EnableSsl = mailSetting.EMAIL_ENABLE_SSL;
  }
  public async Task<ResponseDTO> SendMail(MailMessage mailData, EmailTemplateData data, NotificationCategoryModel notificationCategory, CandidateModel recieverCandidate, CandidateModel senderCandidate, long[] matchCandidates, ProductModel product = null)
  {
    try
    {
      if (mailData == null) return response.GetCommonSuccessResponse(null);

      if (mailData.From == null) mailData.From = new MailAddress(mailSetting.FROM_MAIL_ID, mailSetting.SENDER_NAME);
      if (finderSetting.ENVIRONMENT_NAME != ConfigurationConstant.IsProduction)
      {
        mailData.To.Clear();
        mailData.To.Add(new MailAddress(finderSetting.DEFAULT_RECEIVER_EMAIL));
      }

      smtpClient.Send(mailData);

      if (notificationCategory != null)
      {
        var emailHistory = new EmailNotificationDataModel
        {
          SenderCandidate = senderCandidate,
          RecieverCandidate = recieverCandidate,
          Notification = notificationCategory,
          Product = product,
          Data = data,
          CreatedDateTime = DateTime.UtcNow,
          EmailId = string.Join(", ", mailData.To.Select(m => m.Address)),
          IsSend = true,
          Template = notificationCategory.EmailTemplateUrl,
          ProcessedDateTime = DateTime.UtcNow
        };
        dbContext.EmailNotificationDatas.Add(emailHistory);
        _ = await dbContext.SaveChangesAsync();

        var savemailMatch = new CandidateMailMatchModel
        {
          Candidate = recieverCandidate,
          EmailNotificationData = emailHistory,
          MatchSentTimestamp = DateTime.UtcNow,
          MatchCandidates = matchCandidates
        };
        dbContext.candidateMailMatches.Add(savemailMatch);
        _ = await dbContext.SaveChangesAsync();

      }

      return response.GetCommonSuccessResponse(null);
    }
    catch (Exception ex)
    {

      return response.GetCommonFailureResponse(ex.Message);
    }
  }
  public ResponseDTO SendMail(MailMessage mailData)
  {
    try
    {
      if (mailData.From == null) mailData.From = new MailAddress(mailSetting.FROM_MAIL_ID, mailSetting.SENDER_NAME);
      if (finderSetting.ENVIRONMENT_NAME != ConfigurationConstant.IsProduction)
      {
        mailData.To.Clear();
        mailData.To.Add(new MailAddress(finderSetting.DEFAULT_RECEIVER_EMAIL));
      }
      smtpClient.Send(mailData);

      return response.GetCommonSuccessResponse(null);
    }
    catch (Exception ex)
    {

      return response.GetCommonFailureResponse(ex.Message);
    }
  }
  public MailMessage GetMailContentForWishlist(string mailTo, string subject, string Body)
  {
    TemplateManager template = new TemplateManager(finderSetting, mailSetting, dbContext);
    var mailData = new MailMessage();
    mailData.To.Add(new MailAddress(mailTo));
    mailData.Subject = finderSetting.ENVIRONMENT_NAME == ConfigurationConstant.IsProduction ? subject : $"{subject} ({mailTo})";
    mailData.Body = Body;
    mailData.IsBodyHtml = true;
    return mailData;
  }
  public MailMessage GetMailContent(string mailTo, string subject, string templatePath, EmailTemplateData mailTemplateData)
  {
    if (!IsValidEmail(mailTo)) return null;
    TemplateManager template = new TemplateManager(finderSetting, mailSetting, dbContext);
    var mailData = new MailMessage();
    mailData.To.Add(new MailAddress(mailTo));
    mailData.Subject = subject;
    mailData.Subject = finderSetting.ENVIRONMENT_NAME == ConfigurationConstant.IsProduction ? subject : $"{subject} ({mailTo})";
    mailData.Body = template.GetMailTemplate(templatePath, mailTemplateData);
    mailData.IsBodyHtml = true;

    return mailData;
  }
  public string SelectTemplateBasedOnSubscription(string htmBuilder, string Urlpath, CandidateAndSubscriptionDTO candidate, string unsubscribeUrl, string policyMappingUrl)
  {

    var path = HtmlTemplateConstant.EmailTemplateUrl + Urlpath;

    string template = File.ReadAllText(path);
    template = template.Replace("@BindedHtmlContent", htmBuilder);
    template = template.Replace("@CandidateName", candidate?.candidate?.Name);
    template = template.Replace("@profileId", candidate?.candidate?.ProfileId);
    template = template.Replace("#privacypolicy", finderSetting.FINDER_BASE_URL + policyMappingUrl);
    template = template.Replace("#Unsubscribe", finderSetting.FINDER_BASE_URL + unsubscribeUrl + GetEncriptionUrl(candidate?.candidate?.Id.ToString()));
    template = template.Replace("#websiteUrlBranchLocation", finderSetting.FINDER_BASE_URL + "/help/contact-us");
    template = template.Replace("#websiteUrl", finderSetting.FINDER_BASE_URL);
    return template;
  }
  public string HtmBuilder(string CandidateCode, List<CandidateDetailsDTO> candidateDetails, string UrlPath)
  {
    string html = string.Empty;

    if (CandidateCode == CommonConstant.CelestialCode)
    {
      foreach (var profile in candidateDetails)
      {
        if (profile.IsCelestial)
        {
          html += GetHtmlNContentBuilderForCelestial(profile, true, UrlPath);
        }
        else
        {
          html += GetHtmlNContentBuilderForNormal(profile, true, UrlPath);
        }
      }
    }
    else
    {
      foreach (var profile in candidateDetails)
      {
        if (profile.IsCelestial)
        {
          html += GetHtmlNContentBuilderForCelestial(profile, false, UrlPath);
        }
        else
        {
          html += GetHtmlNContentBuilderForNormal(profile, false, UrlPath);
        }
      }
    }
    return html;
  }
  public string GetHtmlNContentBuilderForNormal(CandidateDetailsDTO profile, bool IsCelestial, string UrlPath)
  {
    if (IsCelestial)
    {
      return $@"
                <div
                  style='
                    padding: 10px 10px;
                    margin-top: 17px;
                    border-radius: 10px;
                    border: 1px solid #eeeeee;
                    background-color: #ffffff;
                  '
                >
                  <div style='align-items: center; padding: 0px'>
                    <div
                      style='
                        border: 1px solid #dfe0e3;
                        width: 108px;
                        padding: 3px;
                        box-sizing: border-box;
                      '
                    >
                      <img
                        src='{profile?.ImageUrl}'
                        alt='Profile Image'
                        style='width: 100px; object-fit: cover; margin-right: 20px'
                      />
                    </div>
                    <div style='margin-top: 10px'>
                      <h2
                        style='
                          font-size: 16px;
                          color: #000;
                          text-decoration: none;
                          outline: none;
                          margin: 0 0 5px;
                        '
                      >
                        {profile?.Name}
                      </h2>
                      <div
                        style='
                          font-size: 14px;
                          color: #851f83;
                          text-decoration: none;
                          outline: none;
                        '
                      >
                        {profile?.ProfileId}
                      </div>
                    </div>
                  </div>
                  <div style='padding: 5px'>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Age
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.Age}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Denomination
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.Denomination}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Education
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.Education}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Workplace
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.Workplace}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Occupation
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.Occupation}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Father Name
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.FatherName}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Mobile
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.ContactDetails?.Mobile}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Residence Ph.Number
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.ContactDetails?.ResidencePhone}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                    <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                      <div
                        style='float: left; width: 45%; color: #666; font-weight: bold'
                      >
                        Address
                      </div>
                      <div
                        style='float: right; width: 55%; color: #333; text-align: left'
                      >
                        {profile?.ContactDetails?.Address}
                      </div>
                      <div style='clear: both'></div>
                    </div>
                  </div>

                  <table style='width: 100%' cellspacing='5' cellpadding='0'>
                    <tbody>
                      <tr>
                        <td style='text-align: left; vertical-align: top'>
                          <a
                            href='#'
                            title='ACCEPT'
                            rel='noreferrer'
                            style='text-decoration: none'
                          >
                            <button
                              style='
                                color: #ffffff;
                                padding-left: 16px;
                                padding-right: 16px;
                                height: 30px;
                                background: #851f83;
                                border-radius: 5px;
                                border: 0px;
                                outline: none;
                              '
                            >
                              <b>FULL PROFILE</b>
                            </button>
                          </a>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>";
    }
    return $@"<div style='padding: 10px 10px; margin-top: 17px; border-radius:10px; border:1px solid #eeeeee;'>
                    <div style='width: 100%;'>
                        <table cellspacing='0' cellpadding='0' border='0'>
                            <tbody>
                                <tr>
                                    <td style='padding-top:10px' valign='top' align='left'>
                                        <div style='border:1px solid #dfe0e3; width:210px; padding:3px; box-sizing:border-box;'>
                                            <a href='#' style='outline:none' target='_blank'>
                                                <img src='{profile?.ImageUrl}' style='display:block;' width='200' border='0'>
                                            </a>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <table cellspacing='0' cellpadding='0' width='100%' border='0'>
                        <tbody>
                            <tr>
                                <td colspan='2' style='padding-top:0px;padding-bottom:0px' valign='top'>
                                    &nbsp;
                                </td>
                                <td style='padding-top:20px;' valign='top' align='left'>
                                    <table cellspacing='0' cellpadding='0' border='0'>
                                        <tbody>
                                            <tr>
                                                <td style='line-height:25px;padding-top: 5px;' valign='top' align='left'>
                                                    <a href='#' style='font-size: 16px; color:#000; text-decoration:none; outline:none;' target='_blank'>
                                                        <b>{profile?.Name}</b>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style='line-height:25px; padding-top:5px; padding-bottom: 10px;' valign='top' align='left'>
                                                    <a href='#' style='font-size: 14px; color:#851f83; text-decoration:none; outline:none;' target='_blank'>
                                                        <b>Chavara ID: {profile?.ProfileId}</b>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign='top' style='line-height:25px; padding-bottom: 10px;'>
                                                    {profile?.Age} Yrs, {profile?.Height}, {profile?.MaritalStatus}, {profile?.Denomination}, {profile?.Education}, {profile?.Occupation}, {profile.Workplace}
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table style='width: 100%;' cellspacing='5' cellpadding='0'>
                        <tbody>
                            <tr>
                                <td style='text-align: left; vertical-align: top;'>
                                    <a href={finderSetting.FINDER_BASE_URL + UrlPath + GetEncriptionUrl(profile.Id.ToString())} title='FULL PROFILE' rel='noreferrer' style='text-decoration: none;'>
                                        <button style='color: #ffffff; padding-left: 16px; padding-right: 16px; height: 30px; background: #851f83; border-radius: 5px; border: 0px; outline: none;'>
                                            <b>FULL PROFILE</b>
                                        </button>
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>";
  }
  public string GetHtmlNContentBuilderForCelestial(CandidateDetailsDTO profile, bool IsCelestial, string UrlPath)
  {
    if (IsCelestial)
    {
      return $@"<div
              style='
                padding: 10px 10px;
                margin-top: 17px;
                border-radius: 10px;
                border: 1px solid #eeeeee;
                background-color: #f5feff;
              '
            >
              <div style='width: 100%'>
                <table cellspacing='0' cellpadding='0' border='0'>
                  <tbody>
                    <tr>
                      <td style='padding-top: 10px' valign='top' align='left'>
                        <div style='padding-bottom: 10px'>
                          <img
                            src='https://photos.chavaramatrimony.com/finder/mails/assets/icons/logo-small.png'
                            style='display: block'
                            width='82'
                            border='0'
                          />
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
              <div style='align-items: center; padding: 0px'>
                <div
                  style='
                    border: 1px solid #dfe0e3;
                    width: 108px;
                    padding: 3px;
                    box-sizing: border-box;
                  '
                >
                  <img
                    src='{profile?.ImageUrl}'
                    alt='Profile Image'
                    style='width: 100px; object-fit: cover; margin-right: 20px'
                  />
                </div>
                <div style='margin-top: 10px'>
                  <h2
                    style='
                      font-size: 16px;
                      color: #000;
                      text-decoration: none;
                      outline: none;
                      margin: 0 0 5px;
                    '
                  >
                    {profile?.Name}
                  </h2>
                  <div
                    style='
                      font-size: 14px;
                      color: #851f83;
                      text-decoration: none;
                      outline: none;
                    '
                  >
                    {profile?.ProfileId}
                  </div>
                </div>
              </div>
              <div style='padding: 5px'>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Age</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.Age}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Denomination</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.Denomination}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Education</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.Education}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Workplace</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.Workplace}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Occupation</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.Occupation}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Father Name</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.FatherName}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Mobile</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.ContactDetails.Mobile}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Residence Ph.Number</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.ContactDetails.ResidencePhone}</div>
                  <div style='clear: both'></div>
                </div>
                <div style='padding: 8px 0; border-bottom: 0px solid #e0e0e0'>
                  <div style='float: left; width: 45%; color: #666; font-weight: bold'>Address</div>
                  <div style='float: right; width: 55%; color: #333; text-align: left'>{profile?.ContactDetails?.Address}</div>
                  <div style='clear: both'></div>
                </div>
              </div>
              <table style='width: 100%' cellspacing='5' cellpadding='0'>
                <tbody>
                  <tr>
                    <td style='text-align: left; vertical-align: top'>
                      <a
                        href='#'
                        title='ACCEPT'
                        rel='noreferrer'
                        style='text-decoration: none'
                      >
                        <button
                          style='
                            color: #ffffff;
                            padding-left: 16px;
                            padding-right: 16px;
                            height: 30px;
                            background: #851f83;
                            border-radius: 5px;
                            border: 0px;
                            outline: none;
                          '
                        >
                          <b>FULL PROFILE</b>
                        </button>
                      </a>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>";
    }
    return $@"
                <div style='padding: 10px 10px; margin-top: 17px; border-radius:10px; border:1px solid #eeeeee; background-color:#F5FEFF;'>
                    <div style='width: 100%;'>
                        <table cellspacing='0' cellpadding='0' border='0'>
                            <tbody>
                                <tr>
                                    <td style='padding-top:10px' valign='top' align='left'>
                                        <div style='padding-bottom: 10px;'>
                                            <img src='https://photos.chavaramatrimony.com/finder/mails/assets/icons/logo-small.png' style='display:block;' width='82' border='0'>
                                        </div>
                                        <div style='border:1px solid #dfe0e3; width:210px; padding:3px; box-sizing:border-box;'>
                                            <a href='#' style='outline:none' target='_blank'>
                                                <img src='{profile?.ImageUrl}' style='display:block;' width='200' border='0'>
                                            </a>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <table cellspacing='0' cellpadding='0' width='100%' border='0'>
                        <tbody>
                            <tr>
                                <td colspan='2' style='padding-top:0px;padding-bottom:0px' valign='top'>
                                    &nbsp;
                                </td>
                                <td style='padding-top:20px;' valign='top' align='left'>
                                    <table cellspacing='0' cellpadding='0' border='0'>
                                        <tbody>
                                            <tr>
                                                <td style='line-height:25px;padding-top: 5px;' valign='top' align='left'>
                                                    <a href='#' style='font-size: 16px; color:#000; text-decoration:none; outline:none;' target='_blank'>
                                                        <b>{profile?.Name}</b>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style='line-height:25px; padding-top:5px; padding-bottom: 10px;' valign='top' align='left'>
                                                    <a href='#' style='font-size: 14px; color:#851f83; text-decoration:none; outline:none;' target='_blank'>
                                                        <b>Chavara ID: {profile?.ProfileId}</b>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign='top' style='line-height:25px; padding-bottom: 10px;'>
                                                    {profile?.Age}Yrs, {profile?.Height}cm, {profile?.MaritalStatus}, {profile?.Denomination}, {profile?.Education}, {profile?.Occupation}, {profile.Workplace}
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table style='width: 100%;' cellspacing='5' cellpadding='0'>
                        <tbody>
                            <tr>
                                <td style='text-align: left; vertical-align: top;'>
                                    <a href={finderSetting.FINDER_BASE_URL + UrlPath + GetEncriptionUrl(profile.Id.ToString())} title='FULL PROFILE' rel='noreferrer' style='text-decoration: none;'>
                                        <button style='color: #ffffff; padding-left: 16px; padding-right: 16px; height: 30px; background: #851f83; border-radius: 5px; border: 0px; outline: none;'>
                                            <b>FULL PROFILE</b>
                                        </button>
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>";
  }

  public string GetEncriptionUrl(string userid)
  {
    if (userid == null) { return null; }
    byte[] key = Encoding.UTF8.GetBytes(CommonConstant.EncriptionKey);
    var encription = new CommonFunctions();
    byte[] useridkey = Encoding.UTF8.GetBytes(userid);
    byte[] encrypt = encription.Encrypt(useridkey, key);
    string encryptedText = HttpUtility.UrlEncode(Convert.ToBase64String(encrypt));
    return encryptedText;
  }
  static bool IsValidEmail(string email)
  {
    if (string.IsNullOrWhiteSpace(email))
      return false;
    try
    {
      // Use built-in .NET email validation (best approach)
      var addr = new System.Net.Mail.MailAddress(email);
      return addr.Address == email;
    }
    catch
    {
      return false;
    }
  }

}
