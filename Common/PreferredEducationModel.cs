using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PreferredEducationModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        [Required]
        public EducationModel Education { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
    }
}