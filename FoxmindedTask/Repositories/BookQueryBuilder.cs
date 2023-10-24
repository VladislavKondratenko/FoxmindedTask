using FoxmindedTask.Contexts.Entities;
using FoxmindedTask.Settings;

namespace FoxmindedTask.Repositories;

public class BookQueryBuilder
{
	private readonly BookFilter _filter;
	private IQueryable<Book> _queryable;

	public BookQueryBuilder(IQueryable<Book> queryable, BookFilter filter)
	{
		_queryable = queryable;
		_filter = filter;
	}

	public IQueryable<Book> Build()
	{
		FilterByTitle();
		FilterByPages();
		FilterByReleaseDate();
		FilterByGenre();
		FilterByAuthor();
		FilterByPublisher();
		
		return _queryable;
	}

	private void FilterByTitle()
	{
		if (string.IsNullOrEmpty(_filter.Title) is false)
			_queryable = _queryable.Where(b => b.Title == _filter.Title);
	}
	
	private void FilterByPages()
	{
		if (_filter.MoreThanPages is not null)
			_queryable = _queryable.Where(b => b.Pages > _filter.MoreThanPages);
		
		if (_filter.LessThanPages is not null)
			_queryable = _queryable.Where(b => b.Pages < _filter.LessThanPages);
	}
	
	private void FilterByReleaseDate()
	{
		if (_filter.PublishedAfter is not null)
			_queryable = _queryable.Where(b => b.ReleaseDate > _filter.PublishedAfter);
		
		if (_filter.PublishedBefore is not null)
			_queryable = _queryable.Where(b => b.ReleaseDate < _filter.PublishedBefore);
	}
	
	private void FilterByGenre()
	{
		if (string.IsNullOrEmpty(_filter.Genre) is false)
			_queryable = _queryable.Where(b => b.Genre.Name == _filter.Genre);
	}
	
	private void FilterByAuthor()
	{
		if (string.IsNullOrEmpty(_filter.Author) is false)
			_queryable = _queryable.Where(b => b.Author.Name == _filter.Author);
	}
	
	private void FilterByPublisher()
	{
		if (string.IsNullOrEmpty(_filter.Publisher) is false)
			_queryable = _queryable.Where(b => b.Publisher.Name == _filter.Publisher);
	}
}