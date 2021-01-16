using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class BaladoCategories : JsonApiController<BaladoCategory>
	{
		public BaladoCategories(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<BaladoCategory, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}