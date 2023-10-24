using FoxmindedTask.Contexts;
using FoxmindedTask.Contexts.Entities;
using FoxmindedTask.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoxmindedTask.Repositories;

public class PublisherRepository : IPublisherRepository
{
	private readonly AppDbContext _context;

	public PublisherRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<bool> IsExistsAsync(string name)
	{
		return await _context.Publishers
			.Where(p => p.Name == name)
			.AnyAsync();
	}

	public async Task<Publisher> GetByNameAsync(string name)
	{
		return await _context.Publishers
			.Where(p => p.Name == name)
			.FirstAsync();
	}
}