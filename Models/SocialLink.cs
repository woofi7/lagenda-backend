using JsonApiDotNetCore.Models;

namespace LagendaBackend.Models
{
	public class SocialLink : Identifiable
	{
		[Attr("link")]
		public string Link { get; set; }

		[Attr("type")]
		public string Type { get; set; }

		[HasOne("author")]
		public Author Author { get; set; }
	}
}