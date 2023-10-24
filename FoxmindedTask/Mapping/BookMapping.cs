using FoxmindedTask.Contexts.Entities;
using FoxmindedTask.Models;

namespace FoxmindedTask.Mapping;

public static class BookMapping
{
	public static Book MapToEntity(this BookDto book)
	{
		var genre = new Genre
		{
			Name = book.Genre
		};

		var author = new Author
		{
			Name = book.Author
		};

		var publisher = new Publisher
		{
			Name = book.Publisher
		};

		return new Book
		{
			Id = book.Id,
			Title = book.Title,
			Pages = book.Pages,
			ReleaseDate = book.ReleaseDate,
			GenreId = genre.Id,
			AuthorId = author.Id,
			PublisherId = publisher.Id,
			Genre = genre,
			Author = author,
			Publisher = publisher
		};
	}
	
	public static BookDto MapToDto(this Book entity)
	{
		return new BookDto
		{
			Id = entity.Id,
			Title = entity.Title,
			Pages = entity.Pages,
			ReleaseDate = entity.ReleaseDate,
			Genre = entity.Genre.Name,
			Author = entity.Author.Name,
			Publisher = entity.Publisher.Name
		};
	}
}