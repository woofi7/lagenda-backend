using System.Collections.Generic;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Models
{
	public class ArticleCategory : Identifiable
	{
		[Attr(PublicName = "name")]
		public string Name { get; set; }

		[Attr(PublicName = "order")]
		public int? Order { get; set; }

		[HasOne(PublicName = "image")]
		public Image Image { get; set; }

		[HasMany(PublicName = "articles")]
		public ICollection<Article> Articles { get; set; }
	}
}