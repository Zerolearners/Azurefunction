using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SourceModel
    {
        public long Id { get; set; }
        [Required]
        public SourceCategoryModel SourceCategory { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public long? MigrationId { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
    }
}