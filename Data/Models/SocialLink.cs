using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Data.Models
{
	public class SocialLink : Identifiable
	{
		[Attr(PublicName = "link")]
		public string Link { get; set; }

		[Attr(PublicName = "type")]
		public string Type { get; set; }

		[HasOne(PublicName = "author")]
		public Author Author { get; set; }
	}
}