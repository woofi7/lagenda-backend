using JsonApiDotNetCore.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class ArticleCategoriesResource : DefaultModelResource<ArticleCategory>
	{
		public ArticleCategoriesResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph, authenticationService)
		{
		}
	}
}