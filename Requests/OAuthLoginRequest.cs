using System.ComponentModel.DataAnnotations;

namespace LagendaBackend.Requests
{
	public class OAuthLoginRequest
	{
		[Required(AllowEmptyStrings = false)]
		public string AuthorizationCode { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Provider { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string RedirectUri { get; set; }
	}
}