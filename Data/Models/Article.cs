using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Resources.Annotations;
using LagendaBackend.Data.Models.ManyToMany;

namespace LagendaBackend.Data.Models
{
	public class Article : Element
	{
		[Attr(PublicName = "content")]
		public string Content { get; set; }

		[HasOne(PublicName = "article-category")]
		public ArticleCategory ArticleCategory { get; set; }

		[HasOne(PublicName = "article-author-category")]
		public ArticleAuthorCategory ArticleAuthorCategory { get; set; }

		[NotMapped]
		[HasManyThrough(nameof(ArticleAuthors))]
		public List<Author> Authors { get; set; }
		public List<ArticleAuthor> ArticleAuthors { get; set; }
	}
}