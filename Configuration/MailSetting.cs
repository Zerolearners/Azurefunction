namespace ai_finder_be_schedulers_donetcore.Configuration;
public class MailSetting
{
    public string SERVER_NAME { get; set; }
    public string MAIL_USERNAME { get; set; }
    public string MAIL_PASSWORD { get; set; }
    public string FROM_MAIL_ID { get; set; }
    public string SENDER_NAME { get; set; }
    public int EMAIL_PORT_NUMBER { get; set; }
    public bool EMAIL_ENABLE_SSL { get; set; }
    public int EMAIL_SEND_LIMIT { get; set; }
    public int EMAIL_SEND_LIMIT_TIME_IN_MINUTES { get; set; }
    public int EMAIL_SEND_BLOCKED_TIME_SPAN_IN_MINUTES { get; set; }
    public string RESET_PASSWORD_BASE_URL { get; set; }
    public int RESET_PASSWORD_TOKEN_EXPIRY_TIME_IN_MINUTES { get; set; }
}
