using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Services;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	[ApiController]
	[DisableRoutingConvention, Route("api/v1/featuredCards")]
	public class FeaturedCardsController : ControllerBase
	{

		public FeaturedCardsController(
			IResourceService<Article, int> resourceService)
		{
			//_resourceService = resourceService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			/*var articles = await _resourceService.GetAsync();

			return Ok(articles);*/
			return Ok();
		}
	}
}