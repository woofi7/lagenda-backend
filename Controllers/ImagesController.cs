using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class ImagesController : JsonApiController<Image>
	{
		public ImagesController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Image, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}