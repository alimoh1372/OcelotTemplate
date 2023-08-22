namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ArticleDb.Entities.Models.ViewModels;

public record ArticleCreateCommand(string Name,string Description,int FkArticleCategoryId);