namespace FoxmindedTask.Contexts.Entities;

public class Book
{
	public Guid Id { get; set; }
	public string Title { get; set; } = null!;
	public int Pages { get; set; }
	public Guid GenreId { get; set; }
	public Guid AuthorId { get; set; }
	public Guid PublisherId { get; set; }
	public DateTime ReleaseDate { get; set; }

	public Genre Genre { get; set; } = null!;
	public Author Author { get; set; } = null!;
	public Publisher Publisher { get; set; } = null!;
}