using FoxmindedTask.Models;
using FoxmindedTask.Settings;

namespace FoxmindedTask.Interfaces;

public interface IBookRepository
{
	Task AddAsync(BookDto book);
	Task<bool> IsExistsAsync(BookDto book);
	Task<IEnumerable<BookDto>> GetByFilterAsync(BookFilter filter);
	Task SaveChangesAsync();
}