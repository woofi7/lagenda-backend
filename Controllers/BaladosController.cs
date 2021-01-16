using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class BaladosController : JsonApiController<Balado>
	{
		public BaladosController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Balado, int> resourceService)
			: base(options, loggerFactory, resourceService)
		{
		}
	}
}