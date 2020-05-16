using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class BaladosController : JsonApiController<Balado>
	{
		public BaladosController(
			IJsonApiOptions jsonApiOptions,
			IResourceService<Balado, int> resourceService,
			ILoggerFactory loggerFactory = null)
			: base(jsonApiOptions, resourceService, loggerFactory)
		{ }
	}
}