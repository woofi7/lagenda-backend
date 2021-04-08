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
		private readonly AppDbContext _appDbContext;
		public BaladosController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Balado, int> resourceService, AppDbContext appDbContext)
			: base(options, loggerFactory, resourceService)
		{
			_appDbContext = appDbContext;
		}

		public override async Task<IActionResult> PostAsync(Balado resource, CancellationToken cancellationToken)
		{
			if (resource.EpisodeNumber == null)
			{
				var n = await _appDbContext.Set<Balado>()
					.Where(b => b.BaladoCategory.Id == resource.BaladoCategory.Id)
					.OrderBy(b => b.EpisodeNumber)
					.Select(b => b.EpisodeNumber)
					.LastOrDefaultAsync(cancellationToken);

				resource.EpisodeNumber = n != null ? n + 1 : 1;
			}
			return await base.PostAsync(resource, cancellationToken);
		}
	}
}