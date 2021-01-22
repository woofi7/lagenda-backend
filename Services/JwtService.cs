#nullable enable
using System;
using Jose;
using LagendaBackend.Configuration;
using LagendaBackend.Models;
using Microsoft.Extensions.Options;

namespace LagendaBackend.Services
{
	public class JwtService
	{
		private readonly IOptions<AuthenticationConfiguration> _authenticationConfiguration;

		public JwtService(IOptions<AuthenticationConfiguration> authenticationConfiguration)
		{
			_authenticationConfiguration = authenticationConfiguration;
		}

		public JwtTokenPayload? DecodeAndVerifyJwt(string? token)
		{
			try
			{
				return JWT.Decode<JwtTokenPayload>(token, Convert.FromBase64String(_authenticationConfiguration.Value.JwtPrimary));
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}