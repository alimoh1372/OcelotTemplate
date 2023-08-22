using Microsoft.EntityFrameworkCore;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql.Types.ProductTypes.ProductAgg;

public class ProductType : ObjectType<Product>
{
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        descriptor.Description("This is a model to show the product in the database");
        descriptor.Field(x => x.Id)
            .Description("The identifier number of product");

        descriptor.Field(x => x.Name)
            .Description("This is the Name of Product");

        descriptor.Field(x => x.Description)
            .Description("Explain some about this field");
        descriptor
            .Field(x => x.ProductCategory.Products)
            .Ignore();

        descriptor
            .Field(x => x.ProductCategory)
            .ResolveWith<Resolvers>(r => r.GetProductCategory(default!, default!))
            .Description("The category of this product");

        base.Configure(descriptor);
    }

    private class Resolvers
    {
        public ProductCategory GetProductCategory([Parent] Product product, ProductDbContext context)
        {
            return context.ProductCategories
                .FirstOrDefault(x => x.Id == product.Fk_ProductCategoryId);
        }
    }

}