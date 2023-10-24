namespace FoxmindedTask.Models;

public class BookDto
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Title { get; set; } = null!;
	public int Pages { get; set; }
	public string Genre { get; set; } = null!;
	public DateTime ReleaseDate { get; set; }
	public string Author { get; set; } = null!;
	public string Publisher { get; set; } = null!;
}