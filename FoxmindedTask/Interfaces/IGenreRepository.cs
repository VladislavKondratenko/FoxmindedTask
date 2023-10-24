using FoxmindedTask.Contexts.Entities;

namespace FoxmindedTask.Interfaces;

public interface IGenreRepository
{
	Task<bool> IsExistsAsync(string name);
	Task<Genre> GetByNameAsync(string name);
}