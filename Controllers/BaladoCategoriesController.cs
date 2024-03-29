using System.Threading;
using System.Threading.Tasks;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class BaladoCategoriesController : JsonApiController<BaladoCategory>
	{
		public BaladoCategoriesController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<BaladoCategory, int> resourceService) : base(options, loggerFactory, resourceService)
		{
		}
	}
}