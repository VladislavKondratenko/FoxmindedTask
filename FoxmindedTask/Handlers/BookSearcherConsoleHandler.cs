using FoxmindedTask.Interfaces;
using FoxmindedTask.Models;
using FoxmindedTask.Repositories;
using FoxmindedTask.Settings;
using Microsoft.Extensions.Configuration;

namespace FoxmindedTask.Handlers;

public class BookSearcherConsoleHandler : IAppSettingsHandler
{
	public async Task HandleAsync()
	{
		var bookFilter = AppSettings.Configuration
			.GetSection(BookFilter.SectionName)
			.Get<BookFilter>();

		ArgumentNullException.ThrowIfNull(bookFilter);

		var books = await GetBooksAsync(bookFilter);

		Console.WriteLine($"{books.Count()} books were found by the filter {bookFilter}:");
	}

	private static async Task<IEnumerable<BookDto>> GetBooksAsync(BookFilter bookFilter)
	{
		await using var repositoryFactory = new RepositoryFactory();

		var bookRepository = repositoryFactory.CreateBookRepository();

		return await bookRepository.GetByFilterAsync(bookFilter);
	}
}