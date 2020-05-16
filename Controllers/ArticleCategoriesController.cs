using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class ArticleCategoriesController : JsonApiController<ArticleCategory>
	{
		public ArticleCategoriesController(
			IJsonApiOptions jsonApiOptions,
			IResourceService<ArticleCategory, int> resourceService,
			ILoggerFactory loggerFactory = null)
			: base(jsonApiOptions, resourceService, loggerFactory)
		{ }
	}
}