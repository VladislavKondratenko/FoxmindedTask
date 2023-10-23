using Microsoft.Data.SqlClient;

namespace FoxmindedTask.Settings;

public record DatabaseSettings
{
	public const string SectionName = "DatabaseSettings";
	
	public string? DataSource { get; init; }
	public string? InitialCatalog { get; init; }
	public bool IntegratedSecurity { get; init; }
	public bool Encrypt { get; init; }
	public bool TrustServerCertificate { get; init; }
	
	public string GetConnectionString()
	{
		SqlConnectionStringBuilder builder = new()
		{
			DataSource = DataSource,
			InitialCatalog = InitialCatalog,
			IntegratedSecurity = IntegratedSecurity,
			Encrypt = Encrypt,
			TrustServerCertificate = TrustServerCertificate
		};

		return builder.ConnectionString;
	}
}