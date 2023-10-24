using FoxmindedTask.Contexts.Entities;

namespace FoxmindedTask.Interfaces;

public interface IPublisherRepository
{
	Task<bool> IsExistsAsync(string name);
	Task<Publisher> GetByNameAsync(string name);
}