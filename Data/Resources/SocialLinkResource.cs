using System;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Errors;
using JsonApiDotNetCore.Hooks.Internal.Execution;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class SocialLinkResource : DefaultModelResource<SocialLink>
	{
		public SocialLinkResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph, authenticationService)
		{
		}
	}
}