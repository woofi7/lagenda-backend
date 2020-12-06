using System;
using JsonApiDotNetCore.Models;

namespace LagendaBackend.Models
{
	public class Element : Identifiable
	{
		[Attr("title")]
		public string Title { get; set; }

		[Attr("post-datetime")]
		public DateTime PostDatetime { get; set; }

		[Attr("update-datetime")]
		public DateTime UpdateDatetime { get; set; }

		[Attr("desc")]
		public string Desc { get; set; }

		[Attr("unlisted")]
		public bool Unlisted { get; set; }

		[HasOne("image")]
		public Image Image { get; set; }
	}
}