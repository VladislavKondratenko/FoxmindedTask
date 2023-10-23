using Microsoft.Extensions.Configuration;

namespace FoxmindedTask;

internal static class AppSettings
{
	private static readonly IConfiguration _configuration = new ConfigurationBuilder()
		.SetBasePath(Directory.GetCurrentDirectory())
		.AddJsonFile("appSettings.json",  optional: false, reloadOnChange: true)
		.Build();

	public static IConfiguration Configuration => _configuration;
}