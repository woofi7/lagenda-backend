using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Data.Models
{
	public class Balado : Element
	{
		[Attr(PublicName = "apple-link")]
		public string AppleLink { get; set; }

		[Attr(PublicName = "google-link")]
		public string GoogleLink { get; set; }

		[Attr(PublicName = "spotify-link")]
		public string SpotifyLink { get; set; }

		[Attr(PublicName = "episode-number")]
		public int EpisodeNumber { get; set; }

		[HasOne(PublicName = "balado-category")]
		public BaladoCategory BaladoCategory { get; set; }
	}
}