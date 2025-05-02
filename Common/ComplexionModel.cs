namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ComplexionModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public long? MigrationId { get; set; }
        public long Order { get; set; }
    }
}