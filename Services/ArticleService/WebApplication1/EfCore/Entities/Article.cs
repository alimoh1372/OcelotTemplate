namespace OcelotTemplate.Services.ArticleManagement.EfCore.Entities;

public class Article
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Fk_ArticleCategoryId { get; set; }
    public ArticleCategory ArticleCategory { get; set; }

}