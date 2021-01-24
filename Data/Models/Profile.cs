using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using LagendaBackend.Clients.Google;

namespace LagendaBackend.Data.Models
{
	public class Profile : Identifiable
	{
		public string GoogleId { get; set; }
		public string Role { get; set; } = "anonymous";

		[Attr(PublicName = "first-name")]
		public string FirstName { get; set; }
		[Attr(PublicName = "family-name")]
		public string FamilyName { get; set; }
		[Attr(PublicName = "email")]
		public string Email { get; set; }
		[Attr(PublicName = "picture")]
		public string Picture { get; set; }

		public static Profile FromGooglePayloadProfile(GoogleTokenPayload payload)
		{
			return new Profile
			{
				GoogleId = payload.Sub,
				FirstName = payload.GivenName,
				FamilyName = payload.FamilyName,
				Email = payload.Email,
				Picture = payload.Picture
			};
		}
	}
}