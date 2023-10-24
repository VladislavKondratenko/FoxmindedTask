using FoxmindedTask.Contexts;
using FoxmindedTask.Contexts.Entities;
using FoxmindedTask.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoxmindedTask.Repositories;

public class GenreRepository : IGenreRepository
{
	private readonly AppDbContext _context;

	public GenreRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<bool> IsExistsAsync(string name)
	{
		return await _context.Genres
			.Where(g => g.Name == name)
			.AnyAsync();
	}

	public async Task<Genre> GetByNameAsync(string name)
	{
		return await _context.Genres
			.Where(g => g.Name == name)
			.FirstAsync();
	}
}