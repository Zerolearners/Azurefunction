namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ProductCategoryModel ProductCategory { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}