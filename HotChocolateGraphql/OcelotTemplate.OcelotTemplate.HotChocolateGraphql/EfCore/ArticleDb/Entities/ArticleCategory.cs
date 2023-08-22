namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Entities;

public class ArticleCategory
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Article> Articles { get; set; } = new List<Article>();
}