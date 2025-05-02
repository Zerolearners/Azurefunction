using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateFamilyModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }

        public FamilyStatusModel FamilyStatus { get; set; }
        public string FatherName { get; set; }
        public string FatherHouseName { get; set; }
        public string FatherNativePlace { get; set; }
        public string FatherProfession { get; set; }
        public string MotherName { get; set; }
        public string MotherHouseName { get; set; }
        public string MotherNativePlace { get; set; }
        public string MotherProfession { get; set; }
        public string AboutFamily { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long? MigrationId { get; set; }
    }
}