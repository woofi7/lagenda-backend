using JsonApiDotNetCore.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class BaladoCategoryResource : DefaultModelResource<BaladoCategory>
	{
		public BaladoCategoryResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph, authenticationService)
		{
		}
	}
}