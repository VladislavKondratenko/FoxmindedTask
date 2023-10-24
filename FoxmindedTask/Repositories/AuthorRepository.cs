using FoxmindedTask.Contexts;
using FoxmindedTask.Contexts.Entities;
using FoxmindedTask.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoxmindedTask.Repositories;

public class AuthorRepository : IAuthorRepository
{
	private readonly AppDbContext _context;

	public AuthorRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<bool> IsExistsAsync(string name)
	{
		return await _context.Authors
			.Where(a => a.Name == name)
			.AnyAsync();
	}

	public async Task<Author> GetByNameAsync(string name)
	{
		return await _context.Authors
			.Where(a => a.Name == name)
			.FirstAsync();
	}
}