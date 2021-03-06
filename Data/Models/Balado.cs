using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Data.Models
{
	public class Balado : Element
	{
		[Attr(PublicName = "simple-cast-id")]
		public string SimpleCastId { get; set; }

		[Attr(PublicName = "apple-link")]
		public string AppleLink { get; set; }

		[Attr(PublicName = "google-link")]
		public string GoogleLink { get; set; }

		[Attr(PublicName = "spotify-link")]
		public string SpotifyLink { get; set; }

		[Attr(PublicName = "soundcloud-link")]
		public string SoundcloudLink { get; set; }

		[Attr(PublicName = "youtube-link")]
		public string YoutubeLink { get; set; }

		[Attr(PublicName = "episode-number")]
		public int EpisodeNumber { get; set; }

		[HasOne(PublicName = "balado-category")]
		public BaladoCategory BaladoCategory { get; set; }
	}
}