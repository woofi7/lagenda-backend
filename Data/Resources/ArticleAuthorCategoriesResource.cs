using JsonApiDotNetCore.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class ArticleAuthorCategoriesResource : DefaultModelResource<ArticleAuthorCategory>
	{
		public ArticleAuthorCategoriesResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph, authenticationService)
		{
		}
	}
}