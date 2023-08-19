namespace OcelotTemplate.Services.ProductManagement.EfCore.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Fk_ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }

}