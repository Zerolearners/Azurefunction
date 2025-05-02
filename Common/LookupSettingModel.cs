using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class LookupSettingModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public LookupTypeModel LookupType { get; set; }
        public long? Value { get; set; }
        public string Code { get; set; }
        public long? MigrationId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}