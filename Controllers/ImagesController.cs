using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class ImagesController : JsonApiController<Image>
	{
		public ImagesController(
			IJsonApiOptions jsonApiOptions,
			IResourceService<Image, int> resourceService,
			ILoggerFactory loggerFactory = null)
			: base(jsonApiOptions, resourceService, loggerFactory)
		{ }
	}
}