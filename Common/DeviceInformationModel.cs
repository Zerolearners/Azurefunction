using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class DeviceInformationModel
    {
        public long Id { get; set; }
        [Obsolete]
        public UserModel User { get; set; }
        [Obsolete]
        public CandidateModel Candidate { get; set; }
        public string Name { get; set; }
        public string OSName { get; set; }
        [Required]
        public ProductModel Product { get; set; }
        public string FirebaseToken { get; set; }
        [Obsolete]
        public DateTime? TimeStamp { get; set; }
        [Obsolete]
        public bool? IsActive { get; set; }
    }
}