using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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