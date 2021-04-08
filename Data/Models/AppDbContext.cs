using LagendaBackend.Data.Models.ManyToMany;
using LagendaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LagendaBackend.Data.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ArticleAuthor>()
				.HasKey(articleAuthor => new { articleAuthor.ArticleId, articleAuthor.AuthorId });
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<ArticleCategory> ArticleCategories { get; set; }
		public DbSet<ArticleAuthorCategory> ArticleAuthorCategories { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Balado> Balados { get; set; }
		public DbSet<BaladoCategory> BaladoCategories { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<ArticleAuthor> ArticleAuthors { get; set; }
		public DbSet<SocialLink> SocialLinks { get; set; }
		public DbSet<Profile> Profiles { get; set; }
		public DbSet<BaladoPartner> BaladoPartners { get; set; }
		public DbSet<File> Files { get; set; }
	}
}