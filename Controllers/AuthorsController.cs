using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class AuthorsController : JsonApiController<Author>
	{
		public AuthorsController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Author, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}