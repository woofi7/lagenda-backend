using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Models;
using LagendaBackend.Models.ManyToMany;

namespace LagendaBackend.Models
{
	public class Article : Element
	{
		[Attr("content")]
		public string Content { get; set; }

		[HasOne("article-category")]
		public ArticleCategory ArticleCategory { get; set; }

		[NotMapped]
		[HasManyThrough(nameof(ArticleAuthors))]
		public List<Author> Authors { get; set; }
		public List<ArticleAuthor> ArticleAuthors { get; set; }
	}
}