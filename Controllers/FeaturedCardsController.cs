using System.Threading.Tasks;
using JsonApiDotNetCore.Controllers.Annotations;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Mvc;

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