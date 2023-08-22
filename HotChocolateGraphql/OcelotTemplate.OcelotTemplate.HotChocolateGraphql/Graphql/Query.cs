
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities;

namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.Graphql;

public class Query
{
    //To available the parallel query from dbcontext and every time it give a instance from dbcontextPool
    // [UseProjection]   //To  handle loading off relation automaticlly load childs



    [UseSorting]
    [UseFiltering]
    public IQueryable<Product> GetProducts(ProductDbContext context)
    { 
        return context.Products;
    }


    [UseSorting]
    [UseFiltering]
    public IQueryable<ProductCategory> GetProductCategories(ProductDbContext context)
    {
        return context.ProductCategories;
    }
   
   // public IQueryable<Article> GetArticles([Service] ArticleDbContext context)
   // {
   //     return context.Articles;
   // }
}