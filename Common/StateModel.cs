using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class StateModel
    {
        public long Id { get; set; }
        [Required]
        public CountryModel Country { get; set; }
        public string Name { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public long? MigrationId { get; set; }
        public bool IsChildRelation { get; set; }
    }
}