namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql.Types.ProductTypes.ProductAgg;

public class AddProductPayloadType:ObjectType<AddProductPayload>
{
    protected override void Configure(IObjectTypeDescriptor<AddProductPayload> descriptor)
    {
        descriptor
            .Field(p=>p.Product)
            .Description("Reperesent the added product...");
        base.Configure(descriptor);
    }
}