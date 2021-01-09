using System;
using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace LagendaBackend.Models
{
	public class ArticleCategory : Identifiable
	{
		[Attr("name")]
		public string Name { get; set; }

		[Attr("order")]
		public int? Order { get; set; }

		[HasOne("image")]
		public Image Image { get; set; }

		[HasMany("articles")]
		public ICollection<Article> Articles { get; set; }
	}
}