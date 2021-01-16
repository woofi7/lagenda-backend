using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Resources.Annotations;
using LagendaBackend.Models.ManyToMany;

namespace LagendaBackend.Models
{
	public class Article : Element
	{
		[Attr(PublicName = "content")]
		public string Content { get; set; }

		[HasOne(PublicName = "article-category")]
		public ArticleCategory ArticleCategory { get; set; }

		[NotMapped]
		[HasManyThrough(nameof(ArticleAuthors))]
		public List<Author> Authors { get; set; }
		public List<ArticleAuthor> ArticleAuthors { get; set; }
	}
}