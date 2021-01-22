using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class ArticleCategoriesController : JsonApiController<ArticleCategory>
	{
		public ArticleCategoriesController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<ArticleCategory, int> resourceService)
			: base(options, loggerFactory, resourceService)
		{
		}
	}
}