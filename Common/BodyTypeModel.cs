namespace ai_finder_be_schedulers_donetcore.Common
{
    public class BodyTypeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public long? MigrationId { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
    }
}