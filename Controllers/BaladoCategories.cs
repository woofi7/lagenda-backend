using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class BaladoCategories : JsonApiController<BaladoCategory>
	{
		public BaladoCategories(IJsonApiContext jsonApiContext, IResourceService<BaladoCategory, int> resourceService, ILoggerFactory loggerFactory) : base(jsonApiContext, resourceService, loggerFactory)
		{
		}
	}
}