namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PhotoPrivacyPolicyTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long[] PhotoTypeIds { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}