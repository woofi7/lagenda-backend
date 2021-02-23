using JsonApiDotNetCore.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class BaladoPartnerResource : DefaultModelResource<BaladoPartner>
	{
		public BaladoPartnerResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph, authenticationService)
		{
		}
	}
}