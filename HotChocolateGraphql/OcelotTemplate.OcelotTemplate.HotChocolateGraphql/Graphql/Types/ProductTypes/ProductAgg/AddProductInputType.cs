using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql.Types.ProductTypes.ProductAgg;

public class AddProductInputType:InputObjectType<AddProductInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddProductInput> descriptor)
    {
        descriptor.Description("A Input type that need to add product");

        descriptor.Field(x => x.Name)
            .Description("The name product...");
        descriptor.Field(x => x.Description)
            .Description("An small description about product");
        descriptor.Field(x => x.Fk_ProductCategoryId)
            .Description("The id of category you want to keep this product");
       

        base.Configure(descriptor);
    }
}