using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class BaladoPartnersController: JsonApiController<BaladoPartner>
	{
		public BaladoPartnersController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<BaladoPartner, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}