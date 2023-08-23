using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql;


public class Subscription
{
    [Subscribe]
    [Topic]
    public Product OnProductAdded([EventMessage] Product product)
    {
        return product;
    }
}