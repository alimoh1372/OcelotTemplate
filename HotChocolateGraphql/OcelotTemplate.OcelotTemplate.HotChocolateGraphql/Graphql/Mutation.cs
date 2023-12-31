﻿using HotChocolate.Subscriptions;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql.Types.ProductTypes.ProductAgg;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql;

public class Mutation
{
    public async Task<AddProductPayload> AddProductAsync(AddProductInput input,
        ProductDbContext context,
       [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var product = new Product
        {

            Name = input.Name,
            Description = input.Description,
            Fk_ProductCategoryId = input.Fk_ProductCategoryId,
        };

        await context.Products.AddAsync(product,cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        await eventSender.SendAsync(nameof(Subscription.OnProductAdded), product, cancellationToken);

        return new AddProductPayload(product);
    }
}