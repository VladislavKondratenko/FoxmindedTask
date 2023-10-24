using FoxmindedTask.Contexts;
using FoxmindedTask.Contexts.Entities;
using FoxmindedTask.Interfaces;
using FoxmindedTask.Mapping;
using FoxmindedTask.Models;
using FoxmindedTask.Settings;
using Microsoft.EntityFrameworkCore;

namespace FoxmindedTask.Repositories;

public class BookRepository : IBookRepository
{
	private readonly AppDbContext _context;
	private readonly IGenreRepository _genreRepository;
	private readonly IAuthorRepository _authorRepository;
	private readonly IPublisherRepository _publisherRepository;

	public BookRepository(AppDbContext context,
		IGenreRepository genreRepository,
		IAuthorRepository authorRepository,
		IPublisherRepository publisherRepository)
	{
		_context = context;
		_genreRepository = genreRepository;
		_authorRepository = authorRepository;
		_publisherRepository = publisherRepository;
	}

	public async Task AddAsync(BookDto book)
	{
		var entity = book.MapToEntity();

		await AdjustGenreAsync(entity);
		await AdjustAuthorAsync(entity);
		await AdjustPublisherAsync(entity);

		await _context.Books.AddAsync(entity);
	}

	public async Task<bool> IsExistsAsync(BookDto book)
	{
		return await _context.Books
			.Where(b => b.Title == book.Title)
			.Where(b => b.Pages == book.Pages)
			.Where(b => b.ReleaseDate == book.ReleaseDate)
			.Where(b => b.Genre.Name == book.Genre)
			.Where(b => b.Author.Name == book.Author)
			.Where(b => b.Publisher.Name == book.Publisher)
			.AnyAsync();
	}

	public async Task<IEnumerable<BookDto>> GetByFilterAsync(BookFilter filter)
	{
		var queryable = _context.Books.AsNoTracking()
			.Include(b => b.Genre)
			.Include(b => b.Author)
			.Include(b => b.Publisher);

		var builtQuery = new BookQueryBuilder(queryable, filter).Build();

		return await builtQuery
			.Select(b => b.MapToDto())
			.ToListAsync();
	}

	public async Task SaveChangesAsync()
	{
		await _context.SaveChangesAsync();
	}

	private async Task AdjustGenreAsync(Book entity)
	{
		if (await _genreRepository.IsExistsAsync(entity.Genre.Name))
		{
			var genre = await _genreRepository.GetByNameAsync(entity.Genre.Name);
			entity.GenreId = genre.Id;
			entity.Genre = genre;
		}
	}

	private async Task AdjustAuthorAsync(Book entity)
	{
		if (await _authorRepository.IsExistsAsync(entity.Author.Name))
		{
			var author = await _authorRepository.GetByNameAsync(entity.Author.Name);
			entity.AuthorId = author.Id;
			entity.Author = author;
		}
	}

	private async Task AdjustPublisherAsync(Book entity)
	{
		if (await _publisherRepository.IsExistsAsync(entity.Publisher.Name))
		{
			var publisher = await _publisherRepository.GetByNameAsync(entity.Publisher.Name);
			entity.PublisherId = publisher.Id;
			entity.Publisher = publisher;
		}
	}
}