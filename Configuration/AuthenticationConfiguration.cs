using System;
using System.ComponentModel.DataAnnotations;

namespace LagendaBackend.Configuration
{
	public class AuthenticationConfiguration
	{
		[Required]
		public string JwtPrimary { get; set;}
		[Required]
		public TimeSpan TokenTTL { get; set;}
	}
}