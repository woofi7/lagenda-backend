using Newtonsoft.Json;

namespace LagendaBackend.Clients.Google
{
	public class GoogleAccessTokenResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("id_token")]
		public string IdToken { get; set; }
	}
}