using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class TownModel
    {
        public long Id { get; set; }
        [Required]
        public DistrictModel District { get; set; }
        public string Name { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
        public Boolean IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public long? MigrationId { get; set; }
    }
}