using FoxmindedTask.Contexts;
using FoxmindedTask.Interfaces;
using FoxmindedTask.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoxmindedTask.Repositories;

public class RepositoryFactory : IDisposable, IAsyncDisposable
{
	private readonly AppDbContext _context;

	public RepositoryFactory()
	{
		var connectionString = GetConnectionString();

		_context = CreateAppDbContext(connectionString);
	}

	public async ValueTask DisposeAsync()
	{
		await _context.DisposeAsync();
	}

	public void Dispose()
	{
		_context.Dispose();
	}

	public IBookRepository CreateBookRepository()
	{
		var genreRepository = new GenreRepository(_context);
		var authorRepository = new AuthorRepository(_context);
		var publisherRepository = new PublisherRepository(_context);

		return new BookRepository(_context,
			genreRepository,
			authorRepository,
			publisherRepository);
	}

	private static string? GetConnectionString()
	{
		var databaseSettings = AppSettings.Configuration
			.GetSection(DatabaseSettings.SectionName)
			.Get<DatabaseSettings>();

		return databaseSettings?.GetConnectionString();
	}

	private static AppDbContext CreateAppDbContext(string? connectionString)
	{
		var options = new DbContextOptionsBuilder<AppDbContext>()
			.UseSqlServer(connectionString)
			.Options;

		return new AppDbContext(options);
	}
}