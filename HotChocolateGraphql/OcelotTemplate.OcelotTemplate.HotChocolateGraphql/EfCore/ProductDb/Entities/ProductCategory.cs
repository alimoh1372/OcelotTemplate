namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

public class ProductCategory
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}