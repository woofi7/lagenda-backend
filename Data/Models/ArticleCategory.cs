using System.Collections.Generic;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Data.Models
{
	public class ArticleCategory : Identifiable
	{
		[Attr(PublicName = "name")]
		public string Name { get; set; }

		[Attr(PublicName = "order")]
		public int? Order { get; set; }

		[Attr(PublicName = "unlisted")]
		public bool Unlisted { get; set; }

		[Attr(PublicName = "is-partner")]
		public bool IsPartner { get; set; }

		[Attr(PublicName = "external-link")]
		public string ExternalLink { get; set; }

		[HasOne(PublicName = "image")]
		public Image Image { get; set; }

		[HasMany(PublicName = "article-author-categories")]
		public ICollection<ArticleAuthorCategory> ArticleAuthorCategories { get; set; }

		[HasMany(PublicName = "articles")]
		public ICollection<Article> Articles { get; set; }
	}
}