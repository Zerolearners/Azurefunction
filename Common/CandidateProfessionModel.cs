using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateProfessionModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        public ProfessionModel Profession { get; set; }
        public string Details { get; set; }
        public OrganizationTypeModel OrganizationType { get; set; }
        public string Organization { get; set; }
        public IncomeModel Income { get; set; }
        public CountryModel WorkingCountry { get; set; }
        public StateModel WorkingState { get; set; }
        public DistrictModel WorkingDistrict { get; set; }
        public TownModel WorkingTown { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}