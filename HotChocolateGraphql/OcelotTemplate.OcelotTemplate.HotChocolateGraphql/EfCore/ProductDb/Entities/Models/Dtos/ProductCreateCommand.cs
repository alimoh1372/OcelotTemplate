namespace OcelotTemplate.OcelotTemplate.HotChocolateGraphql.EfCore.ProductDb.Entities.Models.Dtos;

public record ProductCreateCommand(string Name,string Description,int FkProductCategoryId);