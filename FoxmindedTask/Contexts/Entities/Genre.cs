namespace FoxmindedTask.Contexts.Entities;

public class Genre
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public required string Name { get; set; }

	public ICollection<Book> Books { get; set; } = null!;
}