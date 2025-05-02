using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class LoginInformationModel
    {
        public long Id { get; set; }
        public CandidateModel Candidate { get; set; }
        [Required]
        public UserModel User { get; set; }
        [Required]
        public DeviceInformationModel DeviceInformation { get; set; }
        public DateTime Timestamp { get; set; }
        [Required]
        public IPAddressModel IPAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string BrowsingAppName { get; set; }
        public string NetworkworkProviderName { get; set; }
        public string JwtToken { get; set; }
    }
}