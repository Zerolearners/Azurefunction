using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredLocationModel
    {
        public long Id { get; set; }
    [Required]
    public CandidateModel Candidate { get; set; }
    [Required]
    public CountryModel Country { get; set; }
    public StateModel State { get; set; }
    public DistrictModel District { get; set; }
    public TownModel Town { get; set; }
    public bool IsNative { get; set; }
    public PreferredLocationTypeModel Type { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool IsSelected { get; set; }
    }
}