namespace ai_finder_be_schedulers_donetcore.Common
{
    public class UserModel
    {
     public long Id { get; set; }
    public string Name { get; set; }
    public DesignationModel Designation { get; set; }
    public string EmailId { get; set; }
    public MobileNumberModelDTO PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public string EmailConfirmationToken { get; set; }
    public DateTime? EmailTokenGeneratedTimestamp { get; set; }
    public string PhoneConfirmationToken { get; set; }
    public DateTime? PhoneTokenGeneratedTimestamp { get; set; }
    public long? Otp { get; set; }
    public DateTime? OtpRequestUpdatedTimeStamp { get; set; }
    public DateTime? OtpRequestStartTimeStamp { get; set; }
    public int OtpCount { get; set; }
    public int OtpReEnterCount { get; set; }
    public int? PasswordResetOtp { get; set; }
    public string PasswordResetToken { get; set; }
    public DateTime? PasswordResetTokenUpdatedTimeStamp { get; set; }
    public DateTime? PasswordResetTokenStartTimeStamp { get; set; }
    public DateTime? PasswordResetOtpRequestStartTimeStamp { get; set; }
    public DateTime? PasswordResetOtpRequestUpdatedTimeStamp { get; set; }
    public int PasswordResetCount { get; set; }
    public int PasswordResetOtpReEnterCount { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public long? MigrationId { get; set; }
    }
}