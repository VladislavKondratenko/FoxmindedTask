using FoxmindedTask.Contexts.Entities;

namespace FoxmindedTask.Interfaces;

public interface IAuthorRepository
{
	Task<bool> IsExistsAsync(string name);
	Task<Author> GetByNameAsync(string name);
}