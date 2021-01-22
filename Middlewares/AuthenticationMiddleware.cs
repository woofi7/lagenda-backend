using System.Net.Http.Headers;
using System.Threading.Tasks;
using LagendaBackend.Models;
using LagendaBackend.Services;
using LagendaBackend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace LagendaBackend.Middlewares
{
	public class AuthenticationMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly JwtService _jwtService;

		public AuthenticationMiddleware(RequestDelegate next, JwtService jwtService)
		{
			_next = next;
			_jwtService = jwtService;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			ProcessAuthentication(context);

			await _next(context);
		}

		private void ProcessAuthentication(HttpContext context)
		{
			if (!context.Request.Headers.ContainsKey(HeaderNames.Authorization))
				return;

			var ah = AuthenticationHeaderValue.Parse(context.Request.Headers[HeaderNames.Authorization]);

			if (ah.Scheme != "Bearer")
				return;

			var payload =  _jwtService.DecodeAndVerifyJwt(ah.Parameter);

			if (payload == null)
				return;

			context.Items[typeof(JwtTokenPayload)] = payload;
		}
	}
}