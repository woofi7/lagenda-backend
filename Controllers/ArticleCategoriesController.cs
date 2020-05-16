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
			IJsonApiContext jsonApiContext,
			IResourceService<ArticleCategory, int> resourceService,
			ILoggerFactory loggerFactory) : base(jsonApiContext, resourceService, loggerFactory)
		{ }
	}
}