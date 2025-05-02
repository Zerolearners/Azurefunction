namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ConfidentialFilterModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Guid Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}