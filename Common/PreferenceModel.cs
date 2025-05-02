using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferenceModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        public long? HeightMin { get; set; }
        public long? HeightMax { get; set; }
        public long? AgeMin { get; set; }
        public long? AgeMax { get; set; }
        public string PartnerExpectation { get; set; }
        public string PartnerEducation { get; set; }
        public string PartnerProfesssion { get; set; }
        public bool? IsSpecialNeed { get; set; }
        public bool? IsHavingChildern { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
    }
}