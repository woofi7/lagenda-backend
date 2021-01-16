using System;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Models
{
	public class Element : Identifiable
	{
		[Attr(PublicName = "title")]
		public string Title { get; set; }

		[Attr(PublicName = "post-datetime")]
		public DateTime PostDatetime { get; set; }

		[Attr(PublicName = "update-datetime")]
		public DateTime UpdateDatetime { get; set; }

		[Attr(PublicName = "desc")]
		public string Desc { get; set; }

		[Attr(PublicName = "unlisted")]
		public bool Unlisted { get; set; }

		[HasOne(PublicName = "image")]
		public Image Image { get; set; }
	}
}