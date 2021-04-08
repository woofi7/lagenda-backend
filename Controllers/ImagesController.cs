using System;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LagendaBackend.Controllers
{
	public class ImagesController : JsonApiController<Image>
	{
		public ImagesController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Image, int> resourceService) : base(options, loggerFactory, resourceService)
		{
			Console.WriteLine("test");
		}
	}
}