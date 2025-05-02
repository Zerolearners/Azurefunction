namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PageInfoModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string HashCode { get; set; }
        public string Url { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}