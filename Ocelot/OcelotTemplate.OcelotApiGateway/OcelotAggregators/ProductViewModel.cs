namespace OcelotTemplate.OcelotApiGateway.OcelotAggregators;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Fk_ProductCategoryId { get; set; }
    public ProductCategoryViewModel ProductCategory { get; set; }=new ProductCategoryViewModel();
}