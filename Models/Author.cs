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

		[Attr("desc")]
		public string Desc { get; set; }

		[HasOne("image")]
		public Image Image { get; set; }
	}
}