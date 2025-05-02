namespace ai_finder_be_schedulers_donetcore.Common
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MessageCategoryModel MessageCategory { get; set; }
        public MessageStatusModel MessageStatus { get; set; }
        public int DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}