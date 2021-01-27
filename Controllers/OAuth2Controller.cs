using System;
using System.Linq;
using System.Threading.Tasks;
using Jose;
using LagendaBackend.Clients;
using LagendaBackend.Clients.Google;
using LagendaBackend.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using LagendaBackend.Requests;
using LagendaBackend.Response;
using LagendaBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LagendaBackend.Controllers
{
	[Route("/api/v1")]
	[ApiController]
	public class OAuth2Controller : ControllerBase
	{
		private readonly ILogger<OAuth2Controller> _logger;
		private readonly GoogleClient _googleClient;
		private readonly JwtParser _jwtParser;
		private readonly AppDbContext _appDbContext;
		private readonly IOptions<AuthenticationConfiguration> _authenticationConfiguration;

		public OAuth2Controller(ILogger<OAuth2Controller> logger, GoogleClient googleClient, JwtParser jwtParser, AppDbContext appDbContext, IOptions<AuthenticationConfiguration> authenticationConfiguration)
		{
			_logger = logger;
			_googleClient = googleClient;
			_jwtParser = jwtParser;
			_appDbContext = appDbContext;
			_authenticationConfiguration = authenticationConfiguration;
		}

		[HttpPost("oauth2")]
		public async Task<ActionResult> CompleteGoogleAuthenticationAsync(
			[FromBody] OAuthLoginRequest request
		)
		{
			_logger.LogInformation(request.AuthorizationCode);

			var accessTokenResponse = await _googleClient.GetAccessTokenAsync(request.RedirectUri, request.AuthorizationCode);

			var payload = _jwtParser.GetTokenPayload<GoogleTokenPayload>(accessTokenResponse.IdToken);

			var profile = await _appDbContext.Set<Profile>()
				.Where(p => p.GoogleId == payload.Sub)
				.FirstOrDefaultAsync();

			if (profile == null)
			{
				profile = Profile.FromGooglePayloadProfile(payload);
				await _appDbContext.Set<Profile>().AddAsync(profile);
				await _appDbContext.SaveChangesAsync();
			}

			var jwtPayload = new JwtTokenPayload(profile.Id);
			var secretKey = Convert.FromBase64String(_authenticationConfiguration.Value.JwtPrimary);


			var token = JWT.Encode(jwtPayload, secretKey, JwsAlgorithm.HS512);
			var userInfo = UserInfoResponse.FromProfile(profile);

			var result = new AuthenticationResponse
			{
				AccessToken = token,
				UserInfo = userInfo
			};

			return new ObjectResult(result);
		}
	}
}