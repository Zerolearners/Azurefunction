using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CandidateEducationModel
    {
        public long Id { get; set; }
        [Required]
        public CandidateModel Candidate { get; set; }
        [Required]
        public EducationModel Education { get; set; }
        public int Priority { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean IsSelected { get; set; }
    }
}