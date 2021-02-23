using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class ArticleAuthorCategoriesController : JsonApiController<ArticleAuthorCategory>
	{
		public ArticleAuthorCategoriesController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<ArticleAuthorCategory, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}