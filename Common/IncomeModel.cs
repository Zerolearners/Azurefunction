namespace ai_finder_be_schedulers_donetcore.Common
{
    public class IncomeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeprecated { get; set; }
        public long? MigrationId { get; set; }
        public byte Order { get; set; }
        public long? ParentId { get; set; }
        public bool IsLegacyItem { get; set; }
    }
}