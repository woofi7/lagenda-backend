using JsonApiDotNetCore.Models;

namespace LagendaBackend.Models
{
	public class Image : Identifiable
	{
		[Attr("url")]
		public string Url { get; set; }

		[Attr("alt")]
		public string Alt { get; set; }

		[Attr("credits")]
		public string Credits { get; set; }
	}
}