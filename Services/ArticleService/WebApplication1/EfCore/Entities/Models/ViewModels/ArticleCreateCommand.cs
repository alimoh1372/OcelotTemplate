using System.Runtime.CompilerServices;

namespace OcelotTemplate.Services.ArticleManagement.EfCore.Entities.Models.ViewModels;

public record ArticleCreateCommand(string Name,string Description,int FkArticleCategoryId);