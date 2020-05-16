using JsonApiDotNetCore.Models;

namespace LagendaBackend.Models
{
	public class Balado : Element
	{
		[Attr("apple-link")]
		public string AppleLink { get; set; }

		[Attr("google-link")]
		public string GoogleLink { get; set; }

		[Attr("spotify-link")]
		public string SpotifyLink { get; set; }

		[Attr("episode-number")]
		public int EpisodeNumber { get; set; }

		[HasOne("balado-category")]
		public BaladoCategory BaladoCategory { get; set; }
	}
}