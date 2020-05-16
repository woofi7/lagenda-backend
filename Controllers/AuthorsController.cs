using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class AuthorsController : JsonApiController<Author>
	{
		public AuthorsController(
			IJsonApiOptions jsonApiOptions,
			IResourceService<Author, int> resourceService,
			ILoggerFactory loggerFactory = null)
			: base(jsonApiOptions, resourceService, loggerFactory)
		{ }
	}
}