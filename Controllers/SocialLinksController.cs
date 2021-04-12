using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class SocialLinksController : JsonApiController<SocialLink>
	{
		public SocialLinksController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<SocialLink, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}