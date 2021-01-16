using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using LagendaBackend.Models.ManyToMany;

namespace LagendaBackend.Models
{
	public class Author : Identifiable
	{
		[Attr(PublicName = "first-name")]
		public string FirstName { get; set; }

		[Attr(PublicName = "last-name")]
		public string LastName { get; set; }

		[Attr(PublicName = "title")]
		public string Title { get; set; }

		[Attr(PublicName = "desc")]
		public string Desc { get; set; }

		[Attr(PublicName = "collaborator")]
		public bool Collaborator { get; set; }

		[Attr(PublicName = "order")]
		public int? Order { get; set; }

		[HasOne(PublicName = "image")]
		public Image Image { get; set; }

		[HasMany(PublicName = "social-links")]
		public ICollection<SocialLink> SocialLinks { get; set; }

		[NotMapped]
		[HasManyThrough(nameof(ArticleAuthors))]
		public List<Article> Articles { get; set; }
		public List<ArticleAuthor> ArticleAuthors { get; set; }
	}
}