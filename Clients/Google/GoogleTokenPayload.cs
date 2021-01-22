#nullable enable
using Newtonsoft.Json;

namespace LagendaBackend.Clients.Google
{
	// https://developers.google.com/identity/protocols/oauth2/openid-connect#obtaininguserprofileinformation
	public class GoogleTokenPayload
	{
		public string Aud { get; set; } = null!;
		public int Exp { get; set; }
		public int Iat { get; set; }
		public string Iss { get; set; } = null!;
		public string Sub { get; set; } = null!;
		[JsonProperty("at_hash")]
		public string? AtHash { get; set; }
		public string? Azp { get; set; }
		public string? Email { get; set; }
		[JsonProperty("email_verified")]
		public string? EmailVerified { get; set; }
		[JsonProperty("family_name")]
		public string? FamilyName { get; set; }
		[JsonProperty("given_name")]
		public string? GivenName { get; set; }
		public string? Locale { get; set; }
		public string? Name { get; set; }
		public string? Picture { get; set; }
	}
}