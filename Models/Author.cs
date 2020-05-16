using System.Collections.Generic;
using JsonApiDotNetCore.Models;
using LagendaBackend.Models.ManyToMany;

namespace LagendaBackend.Models
{
	public class Author : Identifiable
	{
		[Attr("first-name")]
		public string FirstName { get; set; }

		[Attr("last-name")]
		public string LastName { get; set; }

		[Attr("title")]
		public string Title { get; set; }

		[Attr("desc")]
		public string Desc { get; set; }

		[Attr("collaborator")]
		public bool Collaborator { get; set; }

		[HasOne("image")]
		public Image Image { get; set; }

		[HasMany("social-links")]
		public ICollection<SocialLink> SocialLinks { get; set; }
	}
}