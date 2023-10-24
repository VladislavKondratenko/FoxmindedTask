namespace FoxmindedTask.Settings;

public record BookFilter
{
	public const string SectionName = "BookFilter";
	
	public string? Title {get;set;}
	public string? Genre {get;set;}
	public string? Author {get;set;}
	public string? Publisher {get;set;}
	public int? MoreThanPages {get;set;}
	public int? LessThanPages {get;set;}
	public DateTime? PublishedBefore {get;set;}
	public DateTime? PublishedAfter{get;set;}
}