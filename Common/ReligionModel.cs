namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ReligionModel
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string TreePath { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Order { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public long? MigrationId { get; set; }
        public NameInLanguageModel DisplayName { get; set; }
    }
}