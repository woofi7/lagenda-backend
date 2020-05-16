using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class AuthorsController : JsonApiController<Author>
	{
		public AuthorsController(IJsonApiContext jsonApiContext, IResourceService<Author, int> resourceService, ILoggerFactory loggerFactory) : base(jsonApiContext, resourceService, loggerFactory)
		{
		}
	}
}