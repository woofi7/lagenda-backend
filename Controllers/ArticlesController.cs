using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class ArticlesController : JsonApiController<Article>
	{
		public ArticlesController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Article, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}