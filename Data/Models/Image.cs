using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Data.Models
{
	public class Image : Identifiable
	{
		[Attr(PublicName = "url")]
		public string Url { get; set; }

		[Attr(PublicName = "alt")]
		public string Alt { get; set; }

		[Attr(PublicName = "credits")]
		public string Credits { get; set; }

		public File File { get; set; }

		[Attr(PublicName = "name")]
		public string Name { get; set; }
	}
}