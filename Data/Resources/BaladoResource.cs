using JsonApiDotNetCore.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class BaladoResource : DefaultModelResource<Balado>
	{
		public BaladoResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph, authenticationService)
		{
		}
	}
}