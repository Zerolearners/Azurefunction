using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class DesignationModel
    {
        public long Id { get; set; }
        [Required]
        public NameInLanguageModel Name { get; set; }
        public Guid Code { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}