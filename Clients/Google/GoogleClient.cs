using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LagendaBackend.Clients.Google;
using LagendaBackend.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LagendaBackend.Clients
{
	public class GoogleClient
	{
		private readonly IOptions<GoogleConfiguration> _options;

		private const string TokenApiRequestUri = "https://www.googleapis.com/oauth2/v4/token";

		private HttpClient _httpClient = new HttpClient();

		public GoogleClient(IOptions<GoogleConfiguration> options)
		{
			_options = options;
		}

		public async Task<GoogleAccessTokenResponse> GetAccessTokenAsync(string requestRedirectUri,
			string requestAuthorizationCode)
		{
			var requestArgs = new Dictionary<string, string>
			{
				["redirect_uri"] = requestRedirectUri,
				["code"] = requestAuthorizationCode,
				["grant_type"] = "authorization_code",
				["client_id"] = _options.Value.AppId,
				["client_secret"] = _options.Value.AppSecret
			};

			using var response = await _httpClient.PostAsync(TokenApiRequestUri, new FormUrlEncodedContent(requestArgs));
			response.EnsureSuccessStatusCode();

			 var content = await response.Content.ReadAsStringAsync();

			 return JsonConvert.DeserializeObject<GoogleAccessTokenResponse>(content);
		}
	}
}