namespace OcelotTemplate.Services.ProductManagement.EfCore.Entities.Models.Dtos;

public record ProductCreateCommand(string Name,string Description,int FkProductCategoryId);