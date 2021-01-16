using LagendaBackend.Models.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace LagendaBackend.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{ }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = "Server=localhost;Database=lagenda_api;Password=[x#[t?RCaGSZ#9r7;User=lagenda;";
			optionsBuilder.UseMySql(connectionString,
				ServerVersion.AutoDetect(connectionString),
				mySqlOptions => mySqlOptions.EnableRetryOnFailure()
				);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ArticleAuthor>()
				.HasKey(articleAuthor => new { articleAuthor.ArticleId, articleAuthor.AuthorId });
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<ArticleCategory> ArticleCategories { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Balado> Balados { get; set; }
		public DbSet<BaladoCategory> BaladoCategories { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<ArticleAuthor> ArticleAuthors { get; set; }
		public DbSet<SocialLink> SocialLinks { get; set; }
	}
}