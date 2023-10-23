using FoxmindedTask.Contexts.Configurations;
using FoxmindedTask.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoxmindedTask.Contexts;

public class AppDbContext : DbContext
{
	public DbSet<Book> Books { get; set; } = null!;
	public DbSet<Genre> Genres { get; set; } = null!;
	public DbSet<Author> Authors { get; set; } = null!;
	public DbSet<Publisher> Publishers { get; set; } = null!;

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new BookConfiguration());
		modelBuilder.ApplyConfiguration(new GenreConfiguration());
		modelBuilder.ApplyConfiguration(new AuthorConfiguration());
		modelBuilder.ApplyConfiguration(new PublisherConfiguration());
	}
}