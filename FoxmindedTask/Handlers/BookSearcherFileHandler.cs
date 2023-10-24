using FoxmindedTask.Interfaces;
using FoxmindedTask.Models;
using FoxmindedTask.Repositories;
using FoxmindedTask.Settings;
using Microsoft.Extensions.Configuration;

namespace FoxmindedTask.Handlers;

public class BookSearcherFileHandler : IAppSettingsHandler
{
	private readonly string _directoryPath;

	public BookSearcherFileHandler(string directoryPath)
	{
		_directoryPath = directoryPath;
	}

	public async Task HandleAsync()
	{
		var bookFilter = AppSettings.Configuration
			.GetSection(BookFilter.SectionName)
			.Get<BookFilter>();

		ArgumentNullException.ThrowIfNull(bookFilter);

		var books = await GetBooksAsync(bookFilter);

		var path = $"{_directoryPath}/{DateTime.Now:yyyy.MM.dd HH:mm:ss}.csv";

		var booksAsRows = books
			.DistinctBy(e => e.Title)
			.Select(PrepareBookToPrint)
			.ToList();
		
		booksAsRows.Insert(0, "Title,Pages,Genre,ReleaseDate,Author,Publisher");

		await File.WriteAllLinesAsync(path, booksAsRows);
	}

	private static async Task<IEnumerable<BookDto>> GetBooksAsync(BookFilter bookFilter)
	{
		await using var repositoryFactory = new RepositoryFactory();
		var bookRepository = repositoryFactory.CreateBookRepository();

		return await bookRepository.GetByFilterAsync(bookFilter);
	}

	private static string PrepareBookToPrint(BookDto book)
	{
		return $"{book.Title},{book.Pages},{book.Genre},{book.ReleaseDate:yyyy-MM-dd},{book.Author},{book.Publisher}";
	}
}