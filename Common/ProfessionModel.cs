using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ProfessionModel
    {
        public long Id { get; set; }
        [Required]
        public IndustryModel Industry { get; set; }
        public string Name { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public long? MigrationId { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeprecated { get; set; }
    }
}