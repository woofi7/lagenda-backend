using System;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Errors;
using JsonApiDotNetCore.Hooks.Internal.Execution;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class ArticleResource : DefaultModelResource<Article>
	{
		public ArticleResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph, authenticationService)
		{
		}
	}
}