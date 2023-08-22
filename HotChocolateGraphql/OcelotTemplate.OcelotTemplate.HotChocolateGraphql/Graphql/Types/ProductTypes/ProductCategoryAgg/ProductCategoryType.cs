
using Microsoft.EntityFrameworkCore;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql.Types.ProductTypes.ProductCategoryAgg;

public class ProductCategoryType : ObjectType<ProductCategory>
{
    protected override void Configure(IObjectTypeDescriptor<ProductCategory> descriptor)
    {
        descriptor.Description("This is a grouping of product about its usage");
        descriptor.Field(x => x.Id)
            .Description("This is an identifier number to this category");

        descriptor.Field(x => x.Title)
            .Description("This is a name and small description about category");

        descriptor.Field(x => x.Description)
            .Description("This is a description about this ");

        descriptor
            .Field(x => x.Products)
            .ResolveWith<Resolvers>(x => x.GetProducts(default!, default!))
            .Description("This is the list of available product in product category");


        base.Configure(descriptor);
    }
    private class Resolvers
    {
        //Using parent is the important thing to do so we get productcategory from parent
        public IQueryable<Product> GetProducts([Parent] ProductCategory productCategory, ProductDbContext context)
        {
            return context.Products.Where(x => x.Fk_ProductCategoryId == productCategory.Id);
        }
    }
}
