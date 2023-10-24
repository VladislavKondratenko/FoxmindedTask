using FoxmindedTask.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FoxmindedTask;

internal static class AppSettings
{
	private const string AppSettingsJsonName = "appSettings.json";
	private static DateTime _lastRead;

	private static readonly IConfiguration _configuration = new ConfigurationBuilder()
		.SetBasePath(Directory.GetCurrentDirectory())
		.AddJsonFile(AppSettingsJsonName, false, true)
		.Build();

	private static IEnumerable<IAppSettingsHandler> _handlers = Enumerable.Empty<IAppSettingsHandler>();

	public static IConfiguration Configuration => _configuration;

	public static void TriggerOnChange(IEnumerable<IAppSettingsHandler> handlers)
	{
		_handlers = handlers;
		var directory = Directory.GetCurrentDirectory();

		var fileWatcher = new FileSystemWatcher(directory)
		{
			Filter = AppSettingsJsonName,
			NotifyFilter = NotifyFilters.LastWrite
		};

		fileWatcher.Changed += OnAppSettingsChanged;
		fileWatcher.EnableRaisingEvents = true;
	}

	private static void OnAppSettingsChanged(object sender, FileSystemEventArgs e)
	{
		var now = DateTime.Now;

		var lastRead = now - _lastRead;

		if (lastRead.TotalMilliseconds < 500)
			return;

		var tasks = _handlers
			.Select(handler => handler.HandleAsync())
			.ToArray();

		Task.WaitAll(tasks);

		_lastRead = now;
	}
}