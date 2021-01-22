using JsonApiDotNetCore.Resources;
using LagendaBackend.Models;

namespace LagendaBackend.Data.Models.ManyToMany
{
	public sealed class ArticleAuthor
	{
		public int ArticleId { get; set; }
		public Article Article { get; set; }

		public int AuthorId { get; set; }
		public Author Author { get; set; }
	}
}